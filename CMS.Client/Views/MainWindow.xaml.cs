using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CMS.Client.ViewModels;
using Xceed.Wpf.AvalonDock.Themes;

namespace CMS.Client.Views
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

        private void MonitorsListBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            (sender as ListBox).SelectedItem = null;
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
