using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ZenTestClient
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

            DllImport.Initialize();
            //DllImport.AddStone(3, 3, 1);

            BtnExecuteEnabled = true;
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

                Parameters = new ObservableCollection<ParameterBullet>();
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

        #endregion

        private bool CanExecute(object arg)
        {
            //return Method != null;
            return true;
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

    }
}
