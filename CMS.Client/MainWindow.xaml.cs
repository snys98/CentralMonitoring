using System;
using System.Collections.Generic;
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
using CMS.Client.Views;
using CMS.Client.Views.Dialogs;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Themes;

namespace CMS.Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly IEnumerator<Theme> Themes = new List<Theme>()
        {
            new GenericTheme(),
            new Vs2013BlueTheme(),
            new Vs2013LightTheme(),
            new Vs2013DarkTheme(),
        }.GetEnumerator();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ToggleTheme_OnClick(object sender, RoutedEventArgs e)
        {
            if (Themes.MoveNext())
            {
                this.DockingManager.Theme = Themes.Current;
            }
            Themes.Reset();
        }
    }

    public class PanelTemplateSelector : DataTemplateSelector
    {
        public PanelTemplateSelector()
        {
            
        }

        public DataTemplate MonitorContainerTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MonitorContainerViewModel)
            {
                return MonitorContainerTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }

    public class PanelStyleSelector : StyleSelector
    {
        public PanelStyleSelector()
        {

        }

        public Style MonitorContainerStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is MonitorContainerViewModel)
            {
                return MonitorContainerStyle;
            }
            return base.SelectStyle(item, container);
        }

    }
}
