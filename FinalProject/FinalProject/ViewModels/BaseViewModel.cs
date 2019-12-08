using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using FinalProject.Models;
using FinalProject.Services;

namespace FinalProject.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        //This is a service, I'm guessing? Idk what it does.
            //Trace it back. 
        public IDataStore<Recipe> DataStore => DependencyService.Get<IDataStore<Recipe>>();

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


        //TRACE IT BACK. 
            //I dont know why I need this. 
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
