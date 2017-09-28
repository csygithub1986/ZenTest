using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenTestClient
{
    /// <summary>
    /// 比赛参数设置
    /// </summary>
    public class AISetting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AISetting()
        {

        }

        public int TimePerMove
        {
            get { return _TimePerMove; }
            set
            {
                if (_TimePerMove != value)
                {
                    _TimePerMove = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimePerMove"));
                }
            }
        }
        private int _TimePerMove;

        public int Layout
        {
            get { return _Layout; }
            set
            {
                if (_Layout != value)
                {
                    _Layout = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Layout"));
                }
            }
        }
        private int _Layout;

        public int GameCount
        {
            get { return _GameCount; }
            set
            {
                if (_GameCount != value)
                {
                    _GameCount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GameCount"));

                }
            }
        }
        private int _GameCount;


        ///// <summary>
        ///// 电脑一步设定的时间，如果未配置则无用，单位s，0123顺序分别是黑1，白1，黑2，白2
        ///// </summary>
        //public ObservableCollection<int> TimePerMove
        //{
        //    get { return _TimePerMove; }
        //    set
        //    {
        //        if (_TimePerMove != value)
        //        {
        //            _TimePerMove = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimePerMove"));

        //        }
        //    }
        //}
        //private ObservableCollection<int> _TimePerMove;

        ///// <summary>
        ///// 电脑一步搜索的节点（因为zen.dll没有回调机制，所以这个只是为了预留，目前没有实际作用）
        ///// </summary>
        //public ObservableCollection<int> Layout
        //{
        //    get { return _Layout; }
        //    set
        //    {
        //        if (_Layout != value)
        //        {
        //            _Layout = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Layout"));

        //        }
        //    }
        //}
        //private ObservableCollection<int> _Layout;

        ///// <summary>
        ///// 用于棋力自测或者和其他软件对测时，测试的盘数。与人下请设定为1。
        ///// </summary>
        //public int GameCountForTest
        //{
        //    get { return _GameCountForTest; }
        //    set
        //    {
        //        if (_GameCountForTest != value)
        //        {
        //            _GameCountForTest = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CountForTest"));

        //        }
        //    }
        //}
        //private int _GameCountForTest;
    }
}
