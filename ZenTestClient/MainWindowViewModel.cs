using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;

namespace ZenTestClient
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action OnExit;

        int totalCount = 3;
        int testCount = 1;

        public void Exit()
        {
            OnExit?.Invoke();
        }

        public event Action<object> ArrayChanged;

        public MainWindowViewModel()
        {
            Type type = typeof(DllImport);
            MethodInfo[] infos = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);
            List<MethodInfo> list = infos.ToList();
            list.Sort(new Comparison<MethodInfo>((x, y) =>
            {
                return string.Compare(x.Name, y.Name);
            }));
            Methods = list;

            ExecuteCommand = new CommandBase() { CanExecuteAction = CanExecute, ExecuteAction = Execute };
            VsSelfCommand = new CommandBase() { ExecuteAction = ExecuteVsSelf };
            IsSuicideCommand = new CommandBase() { ExecuteAction = ExecuteIsSuicide };
            IsLegalCommand = new CommandBase() { ExecuteAction = ExecuteIsLegal };
            VsGnugoCommand = new CommandBase() { ExecuteAction = ExecuteVsGnugo };
            GetPointerCommand = new CommandBase() { ExecuteAction = ExecuteGetPointer };
            //DllImport.Initialize(DateTime.Now.ToString("MM-dd HH-mm-ss") + ".zen");//不调用initial，调用其他方法都要出错
            //DllImport.StartThinking(2);
            //Thread.Sleep(500);
            //DllImport.StopThinking();
            BtnExecuteEnabled = true;
        }

        private void ExecuteGetPointer(object obj)
        {
            Type type = typeof(DllImport);
            MethodInfo[] infos = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);
            List<MethodInfo> list = infos.ToList();
            foreach (MethodInfo info in list)
            {
                Console.WriteLine(info.Name + "\t" + info.MethodHandle.GetFunctionPointer().ToString("X"));
            }
        }

        private void ExecuteVsGnugo(object obj)
        {
            VsGnugo vsgnugo = new VsGnugo();
            OnExit += vsgnugo.Exit;
            vsgnugo.OnMsgOutput += Vsgnugo_OnMsgOutput;
            vsgnugo.Start();

            ClientLog.FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "让八子" + testCount + "~ZenVsGnugo.sgf";
            DllImport.ClearBoard();
            DllImport.FixedHandicap(9);
            DllImport.SetNumberOfSimulations(5000);
            moveCount = 0;
            ClientLog.WriteLog("(;AB[pd][dd][pp][jj][dj][pj][jp][jd][dp]BP[gnugo]WP[Zen]");//9
            //ClientLog.WriteLog("(;AB[pd][dd][pp][dj][pj][jp][jd][dp]BP[gnugo]WP[Zen]");//8
            //new Thread(() =>
            // {
            //     Thread.Sleep(2000);
            //     vsgnugo.GenMove(2);
            // }).Start();

            new Thread(() =>
            {
                int nextColor = DllImport.GetNextColor();
                DllImport.StartThinking(nextColor);
                Thread.Sleep(5000);
                DllImport.StopThinking();

                int p0 = 0, p1 = 0;
                bool p2 = false, p3 = false;
                DllImport.ReadGeneratedMove(ref p0, ref p1, ref p2, ref p3);


                DllImport.Play(p0, p1, nextColor);
                moveCount++;
                string msg = string.Format(moveCount + "\tZen:\t{0}", "" + (char)('A' + p0) + (p1 + 1));
                Console.WriteLine(msg);//WriteMsgLine(msg);
                ClientLog.WriteLog(";" + (nextColor == 1 ? "W" : "B") + "[" + (char)('a' + p0) + (char)('a' + p1) + "]");

                //nextColor = DllImport.GetNextColor();
                char gnuX = (char)('A' + p0);
                if (gnuX > 'H')
                {
                    gnuX++;
                }
                vsgnugo.InputMove(nextColor, "" + gnuX + (p1 + 1));

            }).Start();

        }

        private bool Vsgnugo_OnMsgOutput(string obj, Action<int, string> inputMove)
        {
            if (obj.Contains("illegal move"))
            {
                WriteMsgLine("illegal");
                return true;
            }
            if (obj.Contains("resign"))
            {
                ClientLog.WriteLog(")");
                //MessageBox.Show("done");
                ZenVsGnugoOver();
                return true;
            }
            if (obj.Contains("PASS"))
            {
                ClientLog.WriteLog(")");
                //MessageBox.Show("done");
                ZenVsGnugoOver();
                return true;
            }
            obj = obj.Substring(2);

            int opponentColor = DllImport.GetNextColor();
            //分析对手
            DllImport.StartThinking(opponentColor);
            Thread.Sleep(1500);
            DllImport.StopThinking();
            int opX = 0, opY = 0;
            bool opPass = false, opResign = false;
            DllImport.ReadGeneratedMove(ref opX, ref opY, ref opPass, ref opResign);


            char gnugoOutX = char.Parse(obj.Substring(0, 1));
            if (gnugoOutX > 'I')
                gnugoOutX--;
            int x = gnugoOutX - 'A';

            int y = int.Parse(obj.Substring(1, obj.Length - 1)) - 1;
            DllImport.Play(x, y, opponentColor);
            moveCount++;

            string msg = string.Format(moveCount + "\tgnugo:\t{0}", "" + obj);
            Console.WriteLine(msg);//WriteMsgLine(msg);
            ClientLog.WriteLog(";" + (opponentColor == 1 ? "W" : "B") + "[" + (char)('a' + x) + (char)('a' + y) + "]");
            if (x != opX || y != opY)
            {
                ClientLog.WriteLog("LB[" + (char)('a' + opX) + (char)('a' + opY) + ":A]");
                //ClientLog.WriteLog("LB[" + (char)('a' + opX) + (char)('a' + opY) + ":A]C[Zen认为A点可能更好]");
            }

            int nextColor2 = DllImport.GetNextColor();//这一条有时会得不到正确结果
            DllImport.StartThinking(nextColor2);
            Thread.Sleep(1500);
            DllImport.StopThinking();

            int selfX = 0, selfY = 0;
            bool selfPass = false, selfResign = false;
            DllImport.ReadGeneratedMove(ref selfX, ref selfY, ref selfPass, ref selfResign);


            int para0 = 0, para1 = 0, para2 = 0, para3 = 0, para6 = 0;
            float winning = 0;
            byte[] para5 = new byte[19 * 19];
            DllImport.GetTopMoveInfo(para0, ref para1, ref para2, ref para3, ref winning, para5, para6);

            if (selfPass || selfResign)
            {
                ClientLog.WriteLog(")");
                //MessageBox.Show("done");
                ZenVsGnugoOver();
                return true;
            }

            DllImport.Play(selfX, selfY, nextColor2);
            moveCount++;

            //Console.WriteLine("zen\t" + (nextColor2));

            msg = string.Format(moveCount + "\tZen:\t{0}", "" + (char)('A' + selfX) + (selfY + 1) + "\t  " + winning.ToString("G2"));
            Console.WriteLine(msg);//WriteMsgLine(msg);
            ClientLog.WriteLog(";" + (nextColor2 == 1 ? "W" : "B") + "[" + (char)('a' + selfX) + (char)('a' + selfY) + "]C[预估胜率：" + (winning * 100).ToString("G3") + "%]");

            char gnuX = (char)('A' + selfX);
            if (gnuX > 'H')
            {
                gnuX++;
            }
            inputMove(nextColor2, "" + gnuX + (selfY + 1));
            return false;
        }

        private void ZenVsGnugoOver()
        {
            //让子加1
            testCount++;
            if (testCount > totalCount)
            {
                MessageBox.Show("done");
                return;
            }

            //等五秒钟继续
            new Thread(() =>
            {
                Thread.Sleep(5000);
                ExecuteVsGnugo(null);
            }).Start();
        }

        private void ExecuteIsLegal(object obj)
        {
            ClientLog.FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + DateTime.Now.ToString("MM-dd HH-mm-ss") + ".log";

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    for (int turn = 1; turn <= 2; turn++)
                    {
                        if (!DllImport.IsLegal(i, j, turn))
                        {
                            WriteMsgLine("inlegal " + i + "," + j + ":" + turn);
                        }
                    }
                }
            }
            WriteMsgLine("ExcuteIsLegal Over");
        }

        private void ExecuteIsSuicide(object obj)
        {
            ClientLog.FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + DateTime.Now.ToString("MM-dd HH-mm-ss") + ".log";

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    for (int turn = 1; turn <= 2; turn++)
                    {
                        if (DllImport.IsSuicide(i, j, turn))
                        {
                            WriteMsgLine("suicide " + i + "," + j + ":" + turn);
                        }
                    }
                }
            }
            WriteMsgLine("ExcuteIsSuicide Over");
        }

        int moveCount;

        private void ExecuteVsSelf(object obj)
        {
            ClientLog.FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + DateTime.Now.ToString("MM-dd HH-mm-ss") + "~ZenVsZen.sgf";
            DllImport.ClearBoard();
            moveCount = 0;
            new Thread(() =>
            {
                ClientLog.WriteLog("(;WP[Zen]BP[Zen]");
                while (true)
                {
                    int nextColor = DllImport.GetNextColor();
                    DllImport.StartThinking(nextColor);
                    Thread.Sleep(1500);
                    DllImport.StopThinking();

                    bool isThinking = DllImport.IsThinking();


                    int p0 = 0, p1 = 0;
                    bool p2 = false, p3 = false;
                    DllImport.ReadGeneratedMove(ref p0, ref p1, ref p2, ref p3);
                    string msg = string.Format("Turn:{0}, Generated:\t{1}{2}\t{3}\t{4}", nextColor, (char)('A' + p0), p1 + 1, p2, p3);
                    //ClientLog.WriteLog(msg);
                    Console.WriteLine(msg);//WriteMsgLine(msg);

                    //int para0 = 0, para1 = 0, para2 = 0, para3 = 0, para6 = 0;
                    //float para4 = 0;
                    //byte[] para5 = new byte[19 * 19];
                    //DllImport.GetTopMoveInfo(para0, ref para1, ref para2, ref para3, ref para4, para5, para6);
                    //msg = string.Format("Turn:{0}, TopMoveInfo:\t{1}{2}\t{3}\t{4}", nextColor, (char)('A' + para1), para2 + 1, para3, para4);
                    //ClientLog.WriteLog(msg);

                    //int[] output = new int[19 * 19];
                    //DllImport.GetTerritoryStatictics(output);
                    //ArrayChanged?.Invoke(output);

                    if (p2 || p3)
                    {
                        ClientLog.WriteLog(")");
                        //MessageBox.Show("down");
                        return;
                    }

                    DllImport.Play(p0, p1, nextColor);
                    moveCount++;

                    ClientLog.WriteLog(";" + (nextColor == 1 ? "W" : "B") + "[" + (char)('a' + p0) + (char)('a' + p1) + "]");
                    //return;
                }
            }).Start();
        }

        private void Execute(object obj)
        {
            //BtnExecuteEnabled = false;

            new Thread(() =>
            {
                object[] paramArray = Parameters.Select(p => p.Value).ToArray();
                object output = null;

                for (int i = 0; i < Parameters.Count; i++)
                {
                    if (Parameters[i].ParamInfo.ParameterType == typeof(int[]))
                    {
                        paramArray[i] = new int[19 * 19];
                        output = (int[])paramArray[i];
                    }
                    else if (Parameters[i].ParamInfo.ParameterType == typeof(byte[]))
                    {
                        paramArray[i] = new byte[19 * 19];
                        output = (byte[])paramArray[i];
                    }
                }
                object result = Method.Invoke(null, paramArray);//Result用于输出

                App.Current.Dispatcher.Invoke(new Action(() =>
                {
                    Result = result;
                    ArrayChanged?.Invoke(output);
                    BtnExecuteEnabled = true;
                    Console.WriteLine(Method.Name + "返回结果" + result?.ToString());
                    for (int j = 0; j < paramArray.Length; j++)
                    {
                        Parameters[j].Value = paramArray[j];
                    }

                }));
            }).Start();

            //IntPtr ptr;
            //unsafe
            //{
            //    fixed (int* pc = outputReport)
            //    {
            //        ptr = new IntPtr(pc);
            //    }
            //}
        }

        #region 属性
        public object Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }
        private object _Result;

        public bool BtnExecuteEnabled
        {
            get { return _BtnExecuteEnabled; }
            set
            {
                _BtnExecuteEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BtnExecuteEnabled"));
            }
        }
        private bool _BtnExecuteEnabled;

        public List<MethodInfo> Methods
        {
            get { return _Methods; }
            set
            {
                _Methods = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Methods"));
            }
        }
        private List<MethodInfo> _Methods;

        public MethodInfo Method
        {
            get { return _Method; }
            set
            {
                _Method = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Method"));

                //Parameters = new ObservableCollection<ParameterBullet>();
                ParameterInfo[] parameters = _Method.GetParameters();
                var collection = new ObservableCollection<ParameterBullet>();
                foreach (var param in parameters)
                {
                    collection.Add(new ParameterBullet() { ParamInfo = param });
                }
                Parameters = collection;
            }
        }
        private MethodInfo _Method;

        public ObservableCollection<ParameterBullet> Parameters
        {
            get { return _Parameters; }
            set
            {
                _Parameters = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Parameters"));
            }
        }
        private ObservableCollection<ParameterBullet> _Parameters;


        public StringBuilder OutputMsg
        {
            get { return _OutputMsg; }
            set
            {
                if (_OutputMsg != value)
                {
                    _OutputMsg = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OutputMsg"));
                }
            }
        }
        private StringBuilder _OutputMsg = new StringBuilder();

        #endregion

        private bool CanExecute(object arg)
        {
            return Method != null;
            //return true;
        }

        public object InvokeMethod(MethodInfo methodInfo, object[] parameters)
        {
            //Type type = typeof(DllImport);
            //MethodInfo[] methods = type.GetMethods();
            //foreach (MethodInfo methodInfo in methods)
            //{
            object obj = methodInfo.Invoke(this, parameters);
            //}
            return obj;
        }

        public CommandBase ExecuteCommand { get; set; }
        public CommandBase VsSelfCommand { get; set; }
        public CommandBase IsSuicideCommand { get; set; }
        public CommandBase IsLegalCommand { get; set; }
        public CommandBase VsGnugoCommand { get; set; }
        public CommandBase GetPointerCommand { get; set; }



        private void WriteMsgLine(string msg)
        {
            App.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (OutputMsg.Length > 10000)
                {
                    OutputMsg.Clear();
                }
                OutputMsg.AppendLine(msg + "\t" + DateTime.Now.ToString("ss-fff"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OutputMsg"));
            }));
        }
    }
}
