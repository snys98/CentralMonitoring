using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CMS.Client.ViewModels;

namespace CMS.Client.Views
{
    /// <summary>
    /// WaveSimulatorView.xaml 的交互逻辑
    /// </summary>
    public partial class WaveSimulatorView : UserControl
    {


        //public WaveSpeed WaveSpeed
        //{
        //    get { return (WaveSpeed)GetValue(MyPropertyProperty); }
        //    set { SetValue(MyPropertyProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MyPropertyProperty =
        //    DependencyProperty.Register("WaveSpeed", typeof(WaveSpeed), typeof(WaveSimulatorView), new PropertyMetadata(0));


        public WaveSimulatorView()
        {
            InitializeComponent();
        }
    }


    public class BeatToScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? 2.2 : 1.5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
