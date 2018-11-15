using System;
using System.ComponentModel;
namespace TaskApp
{
    public class Airport : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string TravelStatus { get; set; }
        public bool IsDestination { get; set; }
        private bool _isSelected { get; set; }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
