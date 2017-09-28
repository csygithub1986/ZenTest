using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZenTestClient
{
    public class PartnerModeCalculator
    {
        PlayerSetting[] aiSettings;

        public Action<int, int, int, bool, bool> UICallback;
        public Action<int, int, int, bool, bool> LogCallback;
        public Action<int, int, int, bool, bool> HandTurnCallback;//移交顺序


        public PartnerModeCalculator(PlayerSetting[] settings, Action<int, int, int, bool, bool> uICallback)
        {
            aiSettings = settings;
            UICallback = uICallback;
        }

        public void Init()
        {

        }

        //public void Start(int totalCount)
        //{
        //    while (totalCount > 0)
        //    {
        //        bool isOver = false;
        //        int[] nextColor = new int[] { 2, 1, 2, 1 };
        //        int turn = 0;
        //        while (isOver)
        //        {
        //            GetZenMove(nextColor[turn], aiSettings[turn].TimePerMove, ResultCallback);
        //            turn = turn == 3 ? 0 : turn++;
        //        }
        //        totalCount--;
        //    }
        //}


        /// <summary>
        /// Zen走棋
        /// </summary>
        /// <param name="turn"></param>
        public void GetZenMove(int turn)
        {
            new Thread(() =>
            {
                DllImport.StartThinking(aiSettings[turn].Color);
                Thread.Sleep(aiSettings[turn].TimePerMove * 1000);
                DllImport.StopThinking();
                int x = 0, y = 0;
                bool isPass = false, isResign = false;
                DllImport.ReadGeneratedMove(ref x, ref y, ref isPass, ref isResign);
                DealResult(turn, x, y, isPass, isResign);
            }).Start();
        }

        /// <summary>
        /// 获得外部提交的一步棋步
        /// </summary>
        /// <param name="turn"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isPass"></param>
        /// <param name="isResign"></param>
        public void OutsiderMoveArrived(int turn, int x, int y, bool isPass, bool isResign)
        {
            UICallback?.Invoke(turn, x, y, isPass, isResign);
            LogCallback?.Invoke(turn, x, y, isPass, isResign);
            if (isPass)
            {

            }
            if (isResign)
            {

            }

            turn = turn == 3 ? 0 : turn++;
            if (aiSettings[turn].IsZen)
            {
                //如果下一步还是Zen
                GetZenMove(turn);
            }
            else
            {
                //如果不是zen，交出控制
            }
        }


        private void DealResult(int turn, int x, int y, bool isPass, bool isResign)
        {
            UICallback?.Invoke(turn, x, y, isPass, isResign);
            LogCallback?.Invoke(turn, x, y, isPass, isResign);

            if (isPass)
            {

            }
            if (isResign)
            {

            }

            turn = turn == 3 ? 0 : turn++;
            if (aiSettings[turn].IsZen)
            {
                //如果下一步还是Zen
                GetZenMove(turn);
            }
            else
            {
                //如果不是zen，交出控制
            }
        }

    }
}
