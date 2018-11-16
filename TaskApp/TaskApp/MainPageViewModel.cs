using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaskApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private List<Airport> _transitList { get; set; } = new List<Airport>()
        {
            new Airport{Name = "BOS", TravelStatus = "Warning", IsSelected= true, PlaceType = "STOP"},
            new Airport{Name = "LHR", TravelStatus = "Warning", PlaceType = "STOP"},
            new Airport{Name = "NRT", TravelStatus = "Error" , PlaceType = "STOP"},
            new Airport{Name = "CDG", TravelStatus = "Done", PlaceType = "DESTINATION"}
        };

        public List<Airport> TransitList { get => _transitList;
            set
            {
                _transitList = value;
                OnPropertyChanged("TransitList");
            }
        }
       
        public MainPageViewModel()
        {
            //IsTab1Visible = true;
        }

        //private bool _isTab1Visible;
        //public bool IsTab1Visible
        //{
        //    get => _isTab1Visible;
        //    set
        //    {
        //        _isTab1Visible = value;
        //        OnPropertyChanged("IsTab1Visible");
        //    }
        //}

        //private bool _isTab2Visible;
        //public bool IsTab2Visible
        //{
        //    get => _isTab2Visible;
        //    set
        //    {
        //        _isTab2Visible = value;
        //        OnPropertyChanged("IsTab2Visible");
        //    }
        //}

        //bool _isTab3Visible;
        //public bool IsTab3Visible
        //{
        //    get => _isTab3Visible;
        //    set
        //    {
        //        _isTab3Visible = value;
        //        OnPropertyChanged("IsTab3Visible");
        //    }
        //}

        //private bool _isTab4Visible;
        //public bool IsTab4Visible
        //{
        //    get => _isTab4Visible;
        //    set
        //    {
        //        _isTab4Visible = value;
        //        OnPropertyChanged("IsTab4Visible");
        //    }
        //}
        //public void TabClicked(int index)
        //{
        //    IsTab1Visible = IsTab2Visible = IsTab3Visible = IsTab4Visible = false;

        //    switch (index)
        //    {
        //        case 1:
        //            IsTab1Visible = true;
        //            break;
        //        case 2:
        //            IsTab2Visible = true;
        //            break;
        //        case 3:
        //            IsTab3Visible = true;
        //            break;
        //        case 4:
        //            IsTab4Visible = true;
        //            break;

        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
