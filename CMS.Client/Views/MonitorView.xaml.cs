using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CMS.Models.DTO;

namespace CMS.Client.Views
{
    /// <summary>
    /// CMS.Client.xaml 的交互逻辑
    /// </summary>
    public partial class MonitorView : UserControl
    {
        public MonitorView()
        {
            InitializeComponent();
        }

        private void MonitorView_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
    //[ValueConversion(typeof(ObservableCollection<WaveValue>), typeof(ObservableCollection<DataPoint>))]
    //public class WaveValues2DataPointsConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return (value as ObservableCollection<WaveValue>).Select(item=>new DataPoint(item.ReceiveTime.ToOADate(),item.Value));
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
