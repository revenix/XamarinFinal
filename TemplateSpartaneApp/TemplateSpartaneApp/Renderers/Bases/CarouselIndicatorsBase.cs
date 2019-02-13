﻿using System;
using System.Collections;
using System.Linq;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Renderers.Bases
{
    public class CarouselIndicatorsBase : Grid
    {
        private ImageSource UnselectedImageSource = null;
        private ImageSource SelectedImageSource = null;
        private readonly StackLayout _indicators = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand };

        public CarouselIndicatorsBase()
        {
            HorizontalOptions = LayoutOptions.CenterAndExpand;
            RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            Children.Add(_indicators);
        }

        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(int), typeof(CarouselIndicatorsBase), 0, BindingMode.TwoWay, propertyChanging: PositionChanging);
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(CarouselIndicatorsBase), Enumerable.Empty<object>(), BindingMode.OneWay, propertyChanged: ItemsChanged);
        public static readonly BindableProperty SelectedIndicatorProperty = BindableProperty.Create(nameof(SelectedIndicator), typeof(string), typeof(CarouselIndicatorsBase), "", BindingMode.OneWay);
        public static readonly BindableProperty UnselectedIndicatorProperty = BindableProperty.Create(nameof(UnselectedIndicator), typeof(string), typeof(CarouselIndicatorsBase), "", BindingMode.OneWay);
        public static readonly BindableProperty IndicatorWidthProperty = BindableProperty.Create(nameof(IndicatorWidth), typeof(double), typeof(CarouselIndicatorsBase), 0.0, BindingMode.OneWay);
        public static readonly BindableProperty IndicatorHeightProperty = BindableProperty.Create(nameof(IndicatorHeight), typeof(double), typeof(CarouselIndicatorsBase), 0.0, BindingMode.OneWay);


        public string SelectedIndicator
        {
            get { return (string)this.GetValue(SelectedIndicatorProperty); }
            set { this.SetValue(SelectedIndicatorProperty, value); }
        }

        public string UnselectedIndicator
        {
            get { return (string)this.GetValue(UnselectedIndicatorProperty); }
            set { this.SetValue(UnselectedIndicatorProperty, value); }
        }

        public double IndicatorWidth
        {
            get { return (double)this.GetValue(IndicatorWidthProperty); }
            set { this.SetValue(IndicatorWidthProperty, value); }
        }

        public double IndicatorHeight
        {
            get { return (double)this.GetValue(IndicatorHeightProperty); }
            set { this.SetValue(IndicatorHeightProperty, value); }
        }

        public int Position
        {
            get { return (int)this.GetValue(PositionProperty); }
            set { this.SetValue(PositionProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, (object)value); }
        }

        private void Clear()
        {
            _indicators.Children.Clear();
        }

        private void Init(int position)
        {

            if (UnselectedImageSource == null)
                UnselectedImageSource = ImageSource.FromFile(UnselectedIndicator);

            if (SelectedImageSource == null)
                SelectedImageSource = ImageSource.FromFile(SelectedIndicator);

            if (_indicators.Children.Count > 0)
            {
                for (int i = 0; i < _indicators.Children.Count; i++)
                {
                    if (((Image)_indicators.Children[i]).ClassId == nameof(State.Selected) && i != position)
                        _indicators.Children[i] = BuildImage(State.Unselect, i);
                    else if (((Image)_indicators.Children[i]).ClassId == nameof(State.Unselect) && i == position)
                        _indicators.Children[i] = BuildImage(State.Selected, i);
                }
            }
            else
            {
                var enumerator = ItemsSource.GetEnumerator();
                int count = 0;
                while (enumerator.MoveNext())
                {
                    Image image = null;
                    if (position == count)
                        image = BuildImage(State.Selected, count);
                    else
                        image = BuildImage(State.Unselect, count);

                    _indicators.Children.Add(image);

                    count++;
                }
            }
        }

        private Image BuildImage(State state, int position)
        {
            var image = new Image()
            {
                WidthRequest = IndicatorWidth,
                HeightRequest = IndicatorHeight,
                ClassId = state.ToString()
            };

            switch (state)
            {
                case State.Selected:
                    image.Source = SelectedImageSource;
                    break;
                case State.Unselect:
                    image.Source = UnselectedImageSource;
                    break;
                default:
                    throw new Exception("Invalid state selected");
            }

            image.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { Position = position; }) });

            return image;
        }

        private static void PositionChanging(object bindable, object oldValue, object newValue)
        {
            var carouselIndicators = bindable as CarouselIndicatorsBase;

            carouselIndicators.Init(Convert.ToInt32(newValue));
        }

        private static void ItemsChanged(object bindable, object oldValue, object newValue)
        {
            var carouselIndicators = bindable as CarouselIndicatorsBase;

            carouselIndicators.Clear();
            carouselIndicators.Init(0);
        }

        public enum State
        {
            Selected,
            Unselect
        }
    }
}
