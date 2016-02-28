using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows.Threading;
using Abt.Controls.SciChart;
using Abt.Controls.SciChart.Model.DataSeries;
using CMS.Client.DataServices;
using GalaSoft.MvvmLight;
using CMS.Models.DTO;

namespace CMS.Client.ViewModels
{
    public class WaveSimulatorViewModel:CmsViewModelBase<WaveSimulatorDataService>
    {

        private IXyDataSeries<double, double> _series0 = new XyDataSeries<double, double>();
        private IXyDataSeries<double, double> _series1 = new XyDataSeries<double, double>() ;
        private IEnumerator<WaveValue> _waveValues;
        private int _currentIndex;
        private long _totalIndex;
        private WaveSpeed _waveSpeed = WaveSpeed.Normal;
        private DoubleRange _xVisibleRange = new DoubleRange(0, 5);
        private DoubleRange _yVisibleRange = new DoubleRange(-0.5, 1.5);
        
        private int _heartRate;
        private bool _waveToggler = true;
        private int _sampleRate = 1000;

        private const int TimerInterval = 20;

        public WaveSimulatorViewModel(WaveSimulatorDataService dataService)
            :base(dataService)
        {
            _waveValues = (DataService.GenTestData() as IEnumerable<WaveValue>).GetEnumerator();

            // Fix chart range in Y-Direction
            var _timer = new Timer(TimerInterval) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        public IXyDataSeries<double, double> CurEcgDataSeries => _waveToggler ? _series0 : _series1;

        public IXyDataSeries<double, double> PastEcgDataSeries => !_waveToggler ? _series0 : _series1;

        ///<summary>
        /// Y轴显示范围
        ///</summary>
        public DoubleRange YVisibleRange
        {
            get { return _yVisibleRange; }
            set { Set(ref _yVisibleRange, value); }
        }

        ///<summary>
        /// X轴显示范围
        ///</summary>
        public DoubleRange XVisibleRange
        {
            get { return _xVisibleRange; }
            set { Set(ref _xVisibleRange, value); }
        }

        ///<summary>
        /// 心率
        ///</summary>
        public int HeartRate => _heartRate;

        /// <summary>
        /// 波形扫描速率
        /// </summary>
        public WaveSpeed WaveSpeed
        {
            get { return _waveSpeed; }
            set { Set(ref _waveSpeed, value); }
        }

        public IEnumerator<WaveValue> WaveValues
        {
            get { return _waveValues; }
            set { _waveValues = value; }
        }

        public int SampleRate
        {
            get { return _sampleRate; }
            set { Set(ref _sampleRate, value); }
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            lock (this)
            {
                for (int i = 0; i < _sampleRate * TimerInterval / 1000; i++)
                {
                    if (!_waveValues.MoveNext())
                        continue;
                    // Get the next voltage and time, and append to the chart
                    double voltage = (double)_waveValues.Current.Value;
                    double xValue = _totalIndex / (double)_sampleRate % XVisibleRange.Max;
                    _totalIndex++;
                    CurEcgDataSeries.Append(xValue, voltage);
                    PastEcgDataSeries.Append(xValue, double.NaN);
                    if ((decimal) xValue < (decimal) (XVisibleRange.Max - 1/(double) _sampleRate))
                        continue;
                    _waveToggler = !_waveToggler;
                    RaisePropertyChanged(nameof(PastEcgDataSeries));
                    RaisePropertyChanged(nameof(CurEcgDataSeries));
                }
            }
        }

        public override void Cleanup()
        {
            //this._timer.Stop();
            //this._timer.Close();
        }
    }
    public enum WaveSpeed
    {
        /// <summary>
        /// 6.25mm/s
        /// </summary>
        VerySlow = 0,

        /// <summary>
        /// 12.5mm/s
        /// </summary>
        Slow = 1,

        /// <summary>
        /// 25mm/s
        /// </summary>
        Normal = 2,

        /// <summary>
        /// 50mm/s
        /// </summary>
        Fast = 3,

        /// <summary>
        /// 100mm/s
        /// </summary>
        VeryFast = 4
    }
}