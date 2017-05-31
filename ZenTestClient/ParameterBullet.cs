﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZenTestClient
{
    public class ParameterBullet : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ParameterInfo _ParamInfo;

        public ParameterInfo ParamInfo
        {
            get { return _ParamInfo; }
            set
            {
                _ParamInfo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ParamInfo"));
            }
        }

        private object _Value;

        public object Value
        {
            get
            {
                if (ParamInfo.ParameterType.Equals(typeof(Int32)))
                {
                    return int.Parse(_Value.ToString());
                }
                return _Value;
            }
            set
            {
                _Value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

    }
}