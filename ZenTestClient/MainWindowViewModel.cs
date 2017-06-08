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

        public void Exit()
        {
            OnExit?.Invoke();
        }

        public event Action<int[]> ArrayChanged;

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
            VsSelfCommand = new CommandBase() { ExecuteAction = ExcuteVsSelf };
            IsSuicideCommand = new CommandBase() { ExecuteAction = ExcuteIsSuicide };
            IsLegalCommand = new CommandBase() { ExecuteAction = ExcuteIsLegal };
            VsGnugoCommand = new CommandBase() { ExecuteAction = ExcuteVsGnugo };
            DllImport.Initialize(DateTime.Now.ToString("MM-dd HH-mm-ss") + ".zen");//不调用initial，调用其他方法都要出错
            //DllImport.AddStone(3, 3, 1);

            BtnExecuteEnabled = true;
        }

        private void ExcuteVsGnugo(object obj)
        {
            VsGnugo vsgnugo = new VsGnugo();
            OnExit += vsgnugo.Exit;
            vsgnugo.OnMsgOutput += Vsgnugo_OnMsgOutput;
            vsgnugo.Start();

            ClientLog.FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + DateTime.Now.ToString("MM-dd HH-mm-ss") + "~ZenVsZen.sgf";
            DllImport.ClearBoard();

            new Thread(() =>
            {
                ClientLog.WriteLog("(;WP[gnugo]BP[Zen]");
                int nextColor = DllImport.GetNextColor();
                DllImport.StartThinking(nextColor);
                Thread.Sleep(1500);
                DllImport.StopThinking();

                int p0 = 0, p1 = 0;
                bool p2 = false, p3 = false;
                DllImport.ReadGeneratedMove(ref p0, ref p1, ref p2, ref p3);

                //if (p2 || p3)
                //{
                //    ClientLog.WriteLog(")");
                //    MessageBox.Show("done");
                //    return;
                //}

                DllImport.Play(p0, p1, nextColor);
                string msg = string.Format("Zen:\t{0}", "" + (char)('A' + p0) + (p1 + 1));
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

        private void Vsgnugo_OnMsgOutput(string obj, Action<int, string> inputMove)
        {
            if (obj == null || obj.Length <= 2)
            {
                return;
            }
            if (obj.Contains("illegal move"))
            {
                WriteMsgLine("illegal");
                return;
            }
            if (obj.Contains("resign"))
            {
                ClientLog.WriteLog(")");
                MessageBox.Show("done");
                return;
            }
            obj = obj.Substring(2);

            int nextColor = DllImport.GetNextColor();
            if (nextColor == 2)
            {

            }

            char gnugoOutX = char.Parse(obj.Substring(0, 1));
            if (gnugoOutX > 'I')
                gnugoOutX--;
            int x = gnugoOutX - 'A';

            int y = int.Parse(obj.Substring(1, obj.Length - 1)) - 1;
            DllImport.Play(x, y, nextColor);
            string msg = string.Format("gnugo:\t{0}", "" + obj);
            Console.WriteLine(msg);//WriteMsgLine(msg);
            ClientLog.WriteLog(";" + (nextColor == 1 ? "W" : "B") + "[" + (char)('a' + x) + (char)('a' + y) + "]");

            int nextColor2 = DllImport.GetNextColor();//这一条有时会得不到正确结果
            //int nextColor2 = 2;
            if (nextColor2 == 1)
            {

            }
            DllImport.StartThinking(nextColor2);
            Thread.Sleep(1500);
            DllImport.StopThinking();

            int p0 = 0, p1 = 0;
            bool p2 = false, p3 = false;
            DllImport.ReadGeneratedMove(ref p0, ref p1, ref p2, ref p3);


            int para0 = 0, para1 = 0, para2 = 0, para3 = 0, para6 = 0;
            float win = 0;
            byte[] para5 = new byte[19 * 19];
            DllImport.GetTopMoveInfo(para0, ref para1, ref para2, ref para3, ref win, para5, para6);

            if (p2 || p3)
            {
                ClientLog.WriteLog(")");
                MessageBox.Show("done");
                return;
            }

            DllImport.Play(p0, p1, nextColor2);
            //Console.WriteLine("zen\t" + (nextColor2));

            msg = string.Format("Zen:\t{0}", "" + (char)('A' + p0) + (p1 + 1)+"\t  "+win.ToString("G2"));
            Console.WriteLine(msg);//WriteMsgLine(msg);
            ClientLog.WriteLog(";" + (nextColor2 == 1 ? "W" : "B") + "[" + (char)('a' + p0) + (char)('a' + p1) + "]");

            char gnuX = (char)('A' + p0);
            if (gnuX > 'H')
            {
                gnuX++;
            }
            inputMove(nextColor2, "" + gnuX + (p1 + 1));
        }

        private void ExcuteIsLegal(object obj)
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

        private void ExcuteIsSuicide(object obj)
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

        private void ExcuteVsSelf(object obj)
        {
            ClientLog.FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + DateTime.Now.ToString("MM-dd HH-mm-ss") + "~ZenVsZen.sgf";
            DllImport.ClearBoard();

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
                        MessageBox.Show("down");
                        return;
                    }

                    DllImport.Play(p0, p1, nextColor);

                    ClientLog.WriteLog(";" + (nextColor == 1 ? "W" : "B") + "[" + (char)('a' + p0) + (char)('a' + p1) + "]");
                    //return;
                }
            }).Start();
        }

        private void Execute(object obj)
        {
            BtnExecuteEnabled = false;

            new Thread(() =>
            {
                object[] paramArray = Parameters.Select(p => p.Value).ToArray();
                int[] output = null;

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
                    }
                }
                object result = Method.Invoke(null, paramArray);//Result用于输出

                App.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Result = result;
                    ArrayChanged?.Invoke(output);
                    BtnExecuteEnabled = true;
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
