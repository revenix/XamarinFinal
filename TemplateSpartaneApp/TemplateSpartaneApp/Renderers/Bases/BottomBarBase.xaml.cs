using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using TemplateSpartaneApp.Renderers.ViewCells;
using Xamarin.Forms.Xaml;
using TemplateSpartaneApp.Models.Bases;

namespace TemplateSpartaneApp.Renderers.Bases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomBarBase : ContentView
    {

        #region Properties
        public static readonly BindableProperty SelectIconColorProperty =
            BindableProperty.Create(nameof(SelectIconColor), typeof(Color), typeof(BottomBarBase), default(Color));

        public Color SelectIconColor
        {
            get => (Color)GetValue(SelectIconColorProperty);
            set => SetValue(SelectIconColorProperty, value);
        }

        public static readonly BindableProperty SelectTitleColorProperty =
            BindableProperty.Create(nameof(SelectTitleColor), typeof(Color), typeof(BottomBarBase), default(Color));

        public Color SelectTitleColor
        {
            get => (Color)GetValue(SelectTitleColorProperty);
            set => SetValue(SelectTitleColorProperty, value);
        }

        public static readonly BindableProperty UnselectIconColorProperty =
            BindableProperty.Create(nameof(UnselectIconColor), typeof(Color), typeof(BottomBarBase), default(Color));

        public Color UnselectIconColor
        {
            get => (Color)GetValue(UnselectIconColorProperty);
            set => SetValue(UnselectIconColorProperty, value);
        }

        public static readonly BindableProperty UnselectTitleColorProperty =
            BindableProperty.Create(nameof(UnselectTitleColor), typeof(Color), typeof(BottomBarBase), default(Color));

        public Color UnselectTitleColor
        {
            get => (Color)GetValue(UnselectTitleColorProperty);
            set => SetValue(UnselectTitleColorProperty, value);
        }

        public static readonly BindableProperty ListItemProperty =
            BindableProperty.Create(nameof(ListItem), typeof(ICollection), typeof(BottomBarBase), default(ICollection));

        public ICollection ListItem
        {
            get => (IList)GetValue(ListItemProperty);
            set => SetValue(ListItemProperty, value);
        }

        public ICommand OnSelectedCommand
        {
            get => (ICommand)GetValue(OnSelectedCommandProperty);
            set => SetValue(OnSelectedCommandProperty, value);
        }

        public static readonly BindableProperty OnSelectedCommandProperty =
            BindableProperty.Create(nameof(OnSelectedCommand), typeof(ICommand), typeof(BottomBarBase), null);

        public int Position
        {
            get => (int)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }

        public static readonly BindableProperty PositionProperty =
            BindableProperty.Create(nameof(Position), typeof(int), typeof(BottomBarBase), null);
        #endregion

        public BottomBarBase()
        {
            InitializeComponent();
            InitialSetup();

        }
        #region Methods
        private void InitialSetup()
        {
            PropertyChanged += BottomBarBasePropertyChanged;
        }
        private void BottomBarBasePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ListItemProperty.PropertyName)
            {
                if (ListItem is INotifyCollectionChanged listItem)
                {
                    UpdateView();
                    listItem.CollectionChanged += ListItemCollectionChanged;
                }
                    
            }
        }
        private void ListItemCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateView();
        }
        #endregion
        #region Methods Views
        private void UpdateView()
        {
            IList iList = ListItem as IList;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTapped;
            for (var i = 0; i < ListItem.Count; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (var i = 0; i < ListItem.Count; i++)
            {
                var item = new BottomBarItemViewCell();
                var viewmodel = iList[i] as BottomBarItem;
                if (i == 0)
                {
                    viewmodel.Select = true;
                    viewmodel.TitleColor = SelectTitleColor;
                    viewmodel.IconColor = SelectIconColor;
                }
                else
                {
                    viewmodel.Select = false;
                    viewmodel.TitleColor = UnselectTitleColor;
                    viewmodel.IconColor = UnselectIconColor;
                }
                item.BindingContext = viewmodel;
                item.GestureRecognizers.Add(tapGestureRecognizer);
                grid.Children.Add(item,i,0);
            }
            carousel.ItemsSource = ListItem;
        }
        private void OnTapped(object sender, EventArgs e)
        {
            var selectedItem = ((BottomBarItemViewCell)sender).BindingContext;
            var item = (BottomBarItem)selectedItem;
            carousel.Position = item.Position;
        }
        #endregion

        private void Carousel_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            IList iList = ListItem as IList;
            for (var i = 0; i < ListItem.Count; i++)
            {
                var viewmodel = iList[i] as BottomBarItem;
                if (viewmodel.Position == e.NewValue)
                {
                    viewmodel.Select = true;
                    viewmodel.TitleColor = SelectTitleColor;
                    viewmodel.IconColor = SelectIconColor;
                }
                else
                {
                    viewmodel.TitleColor = UnselectTitleColor;
                    viewmodel.IconColor = UnselectIconColor;
                    viewmodel.Select = false;
                }
            }
        }
    }
}