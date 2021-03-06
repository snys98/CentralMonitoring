﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CMS.Client.DataServices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CMS.Client.ViewModels
{
    public abstract class CmsViewModelBase<T> : ViewModelBase where T :IDataService
    {
        private T _dataService;

        protected CmsViewModelBase(T dataService)
        {
            this._dataService = dataService;
        }

        public T DataService => _dataService;
    }
}
