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
            CreateTransits();
            //AddDestination();
        }

        private void CreateTransits()
        {
            TransitGridView.RowDefinitions.Add(new RowDefinition
            { Height = new GridLength(140) }
                                                                    );
            for (var i = 0; i < Vm.TransitList.Count; i++)
            {
                Airport airport = Vm.TransitList[i];
                Image AirportImage = new Image
                {
                    Source = airport.IsDestination ? "AirportMarker.png" : "airplane.png",
                    WidthRequest = 50,
                    HeightRequest = 40,
                    HorizontalOptions = LayoutOptions.Center
                };

                Image StatusImage = new Image
                {
                    Source = Vm.GetStatusImage(airport.TravelStatus),
                    HorizontalOptions = LayoutOptions.Center,
                    WidthRequest = 20,
                    HeightRequest = 20,
                    Margin = new Thickness(0, 5, 0, 0)
                };

                Label AirportName = new Label()
                {
                    Text = airport.Name,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.White,
                    Margin = new Thickness(0, 5, 0, 0)
                };

                Image TabLine = new Image
                {
                    Source = "TabbedLine.png",
                    BindingContext = airport,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 5, 0, 0)
                };

                TabLine.SetBinding(IsVisibleProperty, "IsSelected");

                StackLayout stackLayout = new StackLayout
                {
                    Padding = new Thickness(10),
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 140
                };

                stackLayout.Children.Add(AirportImage);
                stackLayout.Children.Add(StatusImage);
                stackLayout.Children.Add(AirportName);
                stackLayout.Children.Add(TabLine);

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    foreach (var a in Vm.TransitList)
                    {
                        a.IsSelected = false;
                    }
                    airport.IsSelected = true;
                    Vm.TabClicked(i);
                };

                stackLayout.GestureRecognizers.Add(tapGestureRecognizer);

                TransitGridView.ColumnDefinitions.Add(new ColumnDefinition
                { Width = new GridLength(1, GridUnitType.Star) }
                                                                    );

                TransitGridView.Children.Add(stackLayout, i, 0);
            }
        }
    }
}
