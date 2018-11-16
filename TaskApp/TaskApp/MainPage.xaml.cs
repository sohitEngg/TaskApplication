using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaskApp
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel Vm;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
            Vm = BindingContext as MainPageViewModel;
        }

    }
}
