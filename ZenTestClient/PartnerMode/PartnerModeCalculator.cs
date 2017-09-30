using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ZenTestClient
{
    public class PartnerModeCalculator
    {
        private int m_TotalGameLoopTimes;
        private int m_CurrentGameTimes;
        private PlayerSetting[] aiSettings;

        public Action<int, int, int, bool, bool> UICallback;
        public Action<int, int, int, bool, bool> LogCallback;
        public Action<int, int, int, bool, bool> GameOverCallback;

        public Action<int> HandTurnCallback;//移交顺序

        /// <summary>
        /// 历史记录 分别记录 步数、x坐标、y坐标、ispass、isresign
        /// </summary>
        private List<Tuple<int, int, bool, bool>> m_History;

        public PartnerModeCalculator(PlayerSetting[] settings, int totalGameLoopTimes)
        {
            aiSettings = settings;
            m_TotalGameLoopTimes = totalGameLoopTimes;
            m_CurrentGameTimes = 1;
        }

        public void InitGame()
        {
            DllImport.Initialize("xxx-" + m_CurrentGameTimes + " " + DateTime.Now.ToString("yyMMddHHmmss") + ".txt");//TODO:文件名，在界面中加入playerName，然后命名
            m_History = new List<Tuple<int, int, bool, bool>>();
        }

        public void Start()
        {
            InitGame();
            if (aiSettings[0].IsZen)
            {
                GetZenMove(0);
            }
            else
            {
                HandTurnCallback?.Invoke(0);
            }
        }


        /// <summary>
        /// Zen走棋（线程）
        /// </summary>
        /// <param name="stepNum"></param>
        public void GetZenMove(int stepNum)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                int turn = stepNum % 4;
                DllImport.SetNumberOfSimulations(aiSettings[turn].Layout);
                DllImport.StartThinking(aiSettings[turn].Color);
                Thread.Sleep(aiSettings[turn].TimePerMove * 1000);
                DllImport.StopThinking();
                int x = 0, y = 0;
                bool isPass = false, isResign = false;
                DllImport.ReadGeneratedMove(ref x, ref y, ref isPass, ref isResign);
                DealZenResult(stepNum, x, y, isPass, isResign);
            });
        }

        /// <summary>
        /// 获得外部提交的一步棋步（非主线程）
        /// </summary>
        /// <param name="stepNum"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isPass"></param>
        /// <param name="isResign"></param>
        public void OutsiderMoveArrived(int stepNum, int x, int y, bool isPass, bool isResign)
        {
            m_History.Add(new Tuple<int, int, bool, bool>(x, y, isPass, isResign));
            UICallback?.Invoke(stepNum, x, y, isPass, isResign);
            LogCallback?.Invoke(stepNum, x, y, isPass, isResign);

            if (isPass)
            {
                if (m_History.Count > 1 && m_History[m_History.Count - 2].Item4)//两手pass
                {
                    if (m_CurrentGameTimes == m_TotalGameLoopTimes)//全部比赛完成
                    {
                        GameOverCallback?.Invoke(stepNum, x, y, isPass, isResign);
                    }
                    else
                    {
                        m_CurrentGameTimes++;
                        Start();//又重新开始
                    }
                    return;
                }
            }

            if (isResign)
            {
                if (m_CurrentGameTimes == m_TotalGameLoopTimes)//全部比赛完成
                {
                    GameOverCallback?.Invoke(stepNum, x, y, isPass, isResign);
                }
                else
                {
                    m_CurrentGameTimes++;
                    Start();//又重新开始
                }
                return;
            }

            stepNum++;
            int turn = stepNum % 4;
            if (aiSettings[turn].IsZen)
            {
                //如果下一步还是Zen
                GetZenMove(stepNum);
            }
            else
            {
                //如果不是zen，交出控制
                HandTurnCallback?.Invoke(stepNum);
            }
        }

        /// <summary>
        /// 处理Zen结果（非主线程）
        /// </summary>
        /// <param name="stepNum"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isPass"></param>
        /// <param name="isResign"></param>
        private void DealZenResult(int stepNum, int x, int y, bool isPass, bool isResign)
        {
            DllImport.Play(stepNum % 2, x, y);
            m_History.Add(new Tuple<int, int, bool, bool>(x, y, isPass, isResign));

            UICallback?.Invoke(stepNum, x, y, isPass, isResign);
            LogCallback?.Invoke(stepNum, x, y, isPass, isResign);

            if (isPass)
            {
                if (m_History.Count > 1 && m_History[m_History.Count - 2].Item4)//两手pass
                {
                    if (m_CurrentGameTimes == m_TotalGameLoopTimes)//全部比赛完成
                    {
                        GameOverCallback?.Invoke(stepNum, x, y, isPass, isResign);
                    }
                    else
                    {
                        m_CurrentGameTimes++;
                        Start();//又重新开始
                    }
                    return;
                }
            }

            if (isResign)
            {
                if (m_CurrentGameTimes == m_TotalGameLoopTimes)//全部比赛完成
                {
                    GameOverCallback?.Invoke(stepNum, x, y, isPass, isResign);
                }
                else
                {
                    m_CurrentGameTimes++;
                    Start();//又重新开始
                }
                return;
            }

            stepNum++;
            int turn = stepNum % 4;
            if (aiSettings[turn].IsZen)
            {
                //如果下一步还是Zen
                GetZenMove(stepNum);
            }
            else
            {
                //如果不是zen，交出控制
                HandTurnCallback?.Invoke(stepNum);
            }
        }

    }
}
