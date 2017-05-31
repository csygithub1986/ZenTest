using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZenTestClient
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public MainWindowViewModel()
        {
            Type type = typeof(DllImport);
            MethodInfo[] infos = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);
            List<MethodInfo> list = infos.ToList();
            Methods = list;

            ExecuteCommand = new CommandBase() { CanExecuteAction = CanExecute, ExecuteAction = Execute };
        }

        private void Execute(object obj)
        {
            Result = Method.Invoke(null, Parameters.Select(p => p.Value).ToArray());
        }

        private object _Result;

        public object Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }


        private bool CanExecute(object arg)
        {
            //return Method != null;
            return true;
        }

        private List<MethodInfo> _Methods;

        public List<MethodInfo> Methods
        {
            get { return _Methods; }
            set
            {
                _Methods = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Methods"));
            }
        }

        private MethodInfo _Method;

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


        private ObservableCollection<ParameterBullet> _Parameters;

        public ObservableCollection<ParameterBullet> Parameters
        {
            get { return _Parameters; }
            set
            {
                _Parameters = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Parameters"));
            }
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
