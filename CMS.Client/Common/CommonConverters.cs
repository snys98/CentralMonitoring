using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace CMS.Client.Common
{
    [ValueConversion(typeof(bool), typeof(Visibility), ParameterType = typeof(Visibility))]
    public class Bool2VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && targetType == typeof(Visibility))
            {
                bool val = (bool)value;
                if (val)
                    return Visibility.Visible;
                else
                    if (parameter is Visibility)
                    return parameter;
                else
                    return Visibility.Collapsed;
            }
            if (value == null)
            {
                if (parameter is Visibility)
                    return parameter;
                else
                    return Visibility.Collapsed;
            }
            throw new ArgumentException("Invalid argument/return type. Expected argument: bool and return type: Visibility");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility && targetType == typeof(bool))
            {
                Visibility val = (Visibility)value;
                if (val == Visibility.Visible)
                    return true;
                else
                    return false;
            }
            throw new ArgumentException("Invalid argument/return type. Expected argument: Visibility and return type: bool");
        }
    }

    [ValueConversion(typeof(bool), typeof(bool))]
    public class BoolInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && targetType == typeof(bool))
            {
                return !(bool)value;
            }
            throw new ArgumentException("Invalid argument/return type. Expected argument: bool and return type: Visibility");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && targetType == typeof(bool))
            {
                return !(bool)value;
            }
            throw new ArgumentException("Invalid argument/return type. Expected argument: Visibility and return type: bool");
        }
    }

    public class ChainConverterGroup : List<IValueConverter>, IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return this.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, culture));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            this.Reverse();
            var result = this.Aggregate(value, (current, converter) => converter.ConvertBack(current, targetType, parameter, culture));
            this.Reverse();
            return result;
        }

        #endregion
    }
}
