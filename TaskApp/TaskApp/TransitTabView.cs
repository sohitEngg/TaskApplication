using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TaskApp
{
    public class TransitTabView : ContentView
    {
        #region Fields

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(IEnumerable<Airport>), typeof(TransitTabView),
                                    null, propertyChanged: ItemsSourceChanged);

        #endregion

        #region Constructor

        public TransitTabView()
        {
            Container = GetContainer();
            Content = Container;
        }

        #endregion

        #region Properties

        public IEnumerable<Airport> ItemsSource
        {
            get => (IEnumerable<Airport>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private Layout<View> Container { get; }

        #endregion

        #region Methods

        private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var rg = (TransitTabView)bindable;
            rg.Container.Children.Clear();
            rg.WrapItemsSource();
        }

        protected Layout<View> GetContainer()
        {
            return new Grid { ColumnSpacing = 10 , Margin = new Thickness(15), 
                                HorizontalOptions = LayoutOptions.Center,
                                HeightRequest = 140};
        }

        //private void Add(IList data, int idx)
        //{
        //    var c = Container.Children.Count;

        //    foreach (var d in data)
        //    {
        //        var v = new TransitTab();
        //        Airport airport = ((Airport)d);
        //        v.Image = airport.IsDestination ? "AirportMarker.png" : "airplane.png";
        //        v.StatusImage = GetStatusImage(airport.TravelStatus);
        //        v.TitleText = airport.Name;
        //        v.IsSelected = airport.IsSelected;

        //        if (idx < c)
        //        {
        //            Container.Children.Insert(idx++, v);
        //        }
        //        else
        //        {
        //            Container.Children.Add(v);
        //        }
        //    }
        //}

        private void Remove(IList data, int idx)
        {
            var rms = Container.Children.Skip(idx).Take(data.Count);
            foreach (var airport in rms)
            {
                Container.Children.Remove(airport);
            }
        }

        private void Reset()
        {
            Container.Children.Clear();
            if (ItemsSource != null)
            {
                List<Airport> trasitList = ((List<Airport>)ItemsSource);
                for (var i = 0; i < trasitList.Count; i++)
                {
                    ((Grid)Container).ColumnDefinitions.Add(new ColumnDefinition
                    { Width = new GridLength(1, GridUnitType.Star) });

                    var v = new TransitTab();
                    Airport airport = trasitList[i];
                    v.BindingContext = airport;

                    v.SetBinding(TransitTab.AirportImageProperty, "PlaceType");
                    v.SetBinding(TransitTab.StatusAirportImageProperty, "TravelStatus");
                    v.SetBinding(TransitTab.AirportCodeTextProperty, "Name");
                    v.SetBinding(TransitTab.IsSelectedProperty, "isSelected");

                    v.IsSelected = airport.IsSelected;
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) => {
                        for (var j = 0; j < ((Grid)Container).Children.Count; j++)
                        {
                            ((TransitTab)((Grid)Container).Children.ElementAt(j)).IsSelected = false;
                        }

                        v.IsSelected = true;
                    };

                    v.GestureRecognizers.Add(tapGestureRecognizer);
                    ((Grid)Container).Children.Add(v, i, 0);
                }
            }
        }

        private void WrapItemsSource()
        {
           var notifyCollectionWrapper = new NotifyCollectionWrapper(ItemsSource, null,
                                                                      Remove, Reset,
                                                                      () =>
                                                                      {
                                                                      });
        }

        #endregion
    }
}
