using System;
using System.Collections.Concurrent;
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
using Abt.Controls.SciChart;
using Abt.Controls.SciChart.Model.DataSeries;
using CMS.Client.ViewModels;
using CMS.Models.DTO;

namespace CMS.Client.Views
{
    /// <summary>
    /// WaveSimulatorView.xaml 的交互逻辑
    /// </summary>
    public partial class WaveSimulatorView : UserControl
    {
        //private Timer _timer;

        //public static readonly DependencyProperty YVisibleRangeProperty = DependencyProperty.Register("YVisibleRange",
        //    typeof (DoubleRange), typeof (WaveSimulatorView), new PropertyMetadata(new DoubleRange(-0.5,1.5)));

        //public static readonly DependencyProperty XVisibleRangeProperty = DependencyProperty.Register("XVisibleRange",
        //    typeof (IntegerRange), typeof (WaveSimulatorView), new PropertyMetadata(new IntegerRange(0,5000)));

        //public static readonly DependencyProperty WaveSpeedProperty =
        //    DependencyProperty.Register("WaveSpeed", typeof (WaveSpeed), typeof (WaveSimulatorView),
        //        new PropertyMetadata(WaveSpeed.Normal,SetSpeed));

        //public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register("DataSource", typeof (ConcurrentQueue<WaveValue>), typeof (WaveSimulatorView), new PropertyMetadata(default(ConcurrentQueue<WaveValue>)));

        //private static void SetSpeed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //public IDataSeries<int, double> CurEcgDataSeries { get; set; }

        //public IDataSeries<int, double> PastEcgDataSeries { get; set; }

        //public DoubleRange YVisibleRange
        //{
        //    get { return (DoubleRange) GetValue(YVisibleRangeProperty); }
        //    set { SetValue(YVisibleRangeProperty, value); }
        //}

        //public IntegerRange XVisibleRange
        //{
        //    get { return (IntegerRange) GetValue(XVisibleRangeProperty); }
        //    set { SetValue(XVisibleRangeProperty, value); }
        //}

        //public WaveSpeed WaveSpeed
        //{
        //    get { return (WaveSpeed) GetValue(WaveSpeedProperty); }
        //    set { SetValue(WaveSpeedProperty, value); }
        //}

        //public ConcurrentQueue<WaveValue> DataSource
        //{
        //    get { return (ConcurrentQueue<WaveValue>) GetValue(DataSourceProperty); }
        //    set { SetValue(DataSourceProperty, value); }
        //}


        public WaveSimulatorView()
        {
            InitializeComponent();
        }

        //private async void InitData()
        //{
        //    _timer = this.WaveSpeed.GetTimer();
        //    _timer.Elapsed += TimerOnElapsed;
        //}

        //private async void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        //{
        //    lock (this)
        //    {
        //        while (true)
        //        {
        //            WaveValue data;
        //            if (!DataSource.TryDequeue(out data))
        //                continue;
        //            // Get the next voltage and time, and append to the chart
        //            double voltage = (double)data.Value;
        //            double xValue = _totalIndex / (double)_sampleRate % XVisibleRange.Max;
        //            _totalIndex++;
        //            CurEcgDataSeries.Append(xValue, voltage);
        //            PastEcgDataSeries.Append(xValue, double.NaN);
        //            if ((decimal)xValue < (decimal)(XVisibleRange.Max - 1 / (double)_sampleRate))
        //                continue;
        //            _waveToggler = !_waveToggler;
        //            RaisePropertyChanged(nameof(PastEcgDataSeries));
        //            RaisePropertyChanged(nameof(CurEcgDataSeries));
        //        }
        //    }
        //}

        private void WaveSimulatorView_OnLoaded(object sender, RoutedEventArgs e)
        {
            //InitData();
        }
    }
}
