using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public WaveSimulatorView()
        {
            InitializeComponent();
        }

        private void WaveSimulatorView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as WaveSimulatorViewModel).Cleanup();
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
