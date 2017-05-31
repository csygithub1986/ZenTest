﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ZenTestClient
{
    public class Convertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (targetType == typeof(System.Reflection))
            //{
            //Console.WriteLine(targetType.Name);
            if ("ParamName".Equals(parameter))
            {
                return (value as System.Reflection.ParameterInfo).ParameterType.Name;
            }
            //}
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
