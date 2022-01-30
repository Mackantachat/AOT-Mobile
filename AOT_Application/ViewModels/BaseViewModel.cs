using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using AOT_Application.Models;
using AOT_Application.Services;

namespace AOT_Application.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();
        public CPDataStore<CriminalPersonItem> CPDataStore => DependencyService.Get<CPDataStore<CriminalPersonItem>>()  ;
        public CriminalVehicleDataStore<CriminalVehicleItem> CriminalVehicleDataStore => DependencyService.Get<CriminalVehicleDataStore<CriminalVehicleItem>>();
        public ExtingguisherDataStore<ExtingguisherItem> ExtingguisherDataStore => DependencyService.Get<ExtingguisherDataStore<ExtingguisherItem>>();
        public CheckVehicleDataStore<CheckVechielItem> CheckVehicleDataStore => DependencyService.Get<CheckVehicleDataStore<CheckVechielItem>>();
        public EventNotifyDataStore<EventNotifyItem> EventNotifyDataStore => DependencyService.Get<EventNotifyDataStore<EventNotifyItem>>();


        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
