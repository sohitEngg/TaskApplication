using System;
using Xamarin.Forms;

namespace TaskApp
{
    public class TransitTab: ContentView
    {
        Image _airportImage;         Image _statusImage;         Label _airportName;         Image _tabLine;
         public string TitleText {
            get { return base.GetValue(AirportCodeTextProperty).ToString(); }
            set { base.SetValue(AirportCodeTextProperty, value); }
        }         public static readonly BindableProperty AirportCodeTextProperty = BindableProperty.Create(                                                                 propertyName: "TitleText",                                                                 returnType:typeof(string),                                                                    declaringType:typeof(TransitTab),                                                                    defaultValue:"",                                                                 defaultBindingMode: BindingMode.TwoWay,                                                                 propertyChanged: AirportCodeTextPropertyChanged);          private static void AirportCodeTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)         {             var control = (TransitTab)bindable;             control._airportName.Text = newValue.ToString();         } 

        public string Image
        {
            get { return base.GetValue(AirportImageProperty).ToString(); }
            set { base.SetValue(AirportImageProperty, value); }
        }         public static BindableProperty AirportImageProperty = BindableProperty.Create(                                                         propertyName: "Image",                                                         returnType: typeof(string),                                                         declaringType: typeof(TransitTab),                                                         defaultValue: "",                                                         defaultBindingMode: BindingMode.TwoWay,                                                         propertyChanged: ImageSourcePropertyChanged);            private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)         {             var control = (TransitTab)bindable;             control._airportImage.Source = ImageSource.FromFile(GetPlaceImage(newValue.ToString()));         } 

        public string StatusImage
        {
            get { return base.GetValue(StatusAirportImageProperty).ToString(); }
            set { base.SetValue(StatusAirportImageProperty, value); }
        }         public static BindableProperty StatusAirportImageProperty = BindableProperty.Create(                                                         propertyName: "Image",                                                         returnType: typeof(string),                                                         declaringType: typeof(TransitTab),                                                         defaultValue: "",                                                         defaultBindingMode: BindingMode.TwoWay,                                                         propertyChanged: StatusImageSourcePropertyChanged);          private static void StatusImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)         {             var control = (TransitTab)bindable;             control._statusImage.Source = ImageSource.FromFile(GetStatusImage(newValue.ToString()));         }


        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
                _tabLine.IsVisible = value;
            }
        }

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            "IsSelected", 
            typeof(bool), 
            typeof(TransitTab), 
            false);
         public TransitTab()         {            _airportImage = new Image             {                 WidthRequest = 50,                 HeightRequest = 40,                 HorizontalOptions = LayoutOptions.Center             };              _statusImage = new Image             {                 HorizontalOptions = LayoutOptions.Center,                 WidthRequest = 20,                 HeightRequest = 20,                 Margin = new Thickness(0, 5, 0, 0)             };              _airportName = new Label()             {                 HorizontalOptions = LayoutOptions.Center,                 TextColor = Color.White,                 Margin = new Thickness(0, 5, 0, 0)             };              _tabLine = new Image             {                 Source = "TabbedLine.png",                 HorizontalOptions = LayoutOptions.Center,                 Margin = new Thickness(0, 5, 0, 0)
            };              StackLayout TransitTab = new StackLayout             {                 Padding = new Thickness(10),                 VerticalOptions = LayoutOptions.FillAndExpand,                 HeightRequest = 140             };              TransitTab.Children.Add(_airportImage);             TransitTab.Children.Add(_statusImage);             TransitTab.Children.Add(_airportName);             TransitTab.Children.Add(_tabLine);              Content = TransitTab;         } 
        public static string GetStatusImage(string travelStatus)
        {
            string image = null;
            switch (travelStatus)
            {
                case "Warning":
                    image = "YellowExclamationIcon.png";
                    break;
                case "Error":
                    image = "RedExclamationIcon.png";
                    break;
                case "Done":
                    image = "GreenExclamationIcon.png";
                    break;
            }
            return image;
        }

        public static string GetPlaceImage(string type)
        {
            if (type.Equals("DESTINATION"))
            {
                return "AirportMarker.png";
            }
            return "airplane.png";
        }

    }
}
