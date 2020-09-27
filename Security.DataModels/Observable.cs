using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Security.DataModels
{
    public class Observable : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            OnPropertyChanging(propertyName);
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanging, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            OnPropertyChanging(propertyName);
            onChanging?.Invoke();
            storage = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null) => PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }
}
