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
using System.Windows.Shapes;
using CMS.Client.ViewModels;

namespace CMS.Client.Views.Dialogs
{
    /// <summary>
    /// CreateMonitorDialog.xaml 的交互逻辑
    /// </summary>
    public partial class CreateMonitorDialog : Window
    {
        

        public CreateMonitorDialog()
        {
            InitializeComponent();
        }

        public CreateMonitorDialog(MonitorViewModel vm)
            :this()
        {
            this.DataContext = vm;
        }
    }
}
