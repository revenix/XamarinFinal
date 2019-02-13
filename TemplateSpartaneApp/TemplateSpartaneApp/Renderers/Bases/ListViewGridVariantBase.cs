using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using TemplateSpartaneApp.Renderers.ViewCells;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Renderers.Bases
{
    public class ListViewGridVariantBase : Grid
    {
        #region Properties
        public static readonly BindableProperty ListItemProperty =
            BindableProperty.Create(nameof(ListItem), typeof(ICollection), typeof(ListViewGridVariantBase), default(ICollection));

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
            BindableProperty.Create(nameof(OnSelectedCommand), typeof(ICommand), typeof(ListViewGridVariantBase), null);
        #endregion

        #region Constructor
        public ListViewGridVariantBase()
        {
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            InitialSetup();
        }
        #endregion

        #region Methods
        private void InitialSetup()
        {
            PropertyChanged += ListViewGridVariantBasePropertyChanged;
        }
        private void ListViewGridVariantBasePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ListItemProperty.PropertyName)
            {
                if (ListItem is INotifyCollectionChanged listItem)
                    listItem.CollectionChanged += ListItemCollectionChanged;
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
            Children.Clear();
            var lastHeight = 100;
            var y = 0;
            var leftColumn = new StackLayout();
            var rightColumn = new StackLayout();
            var column = leftColumn;
            var productTapGestureRecognizer = new TapGestureRecognizer();
            productTapGestureRecognizer.Tapped += OnProductTapped;
            for (var i = 0; i < ListItem.Count; i++)
            {
                var item = new GridIVariantItemViewCell();
                if (i > 0)
                {

                    if (i == 3 || i == 4 || i == 7 || i == 8 || i == 11 || i == 12)
                    {
                        lastHeight = 100;
                    }
                    else
                    {
                        lastHeight = 190;
                    }

                    if (i % 2 == 0)
                    {
                        column = leftColumn;
                        y++;
                    }
                    else
                    {
                        column = rightColumn;
                    }
                }
                var viewmodel = iList[i];
                item.HeightRequest = lastHeight;
                item.BindingContext = viewmodel;
                item.GestureRecognizers.Add(productTapGestureRecognizer);
                column.Children.Add(item);
            }
            Children.Add(leftColumn, 0, 0);
            Children.Add(rightColumn, 1, 0);
        }
        private void OnProductTapped(object sender, EventArgs e)
        {
            var selectedItem = ((GridIVariantItemViewCell)sender).BindingContext;
            OnSelectedCommand.Execute(selectedItem);
        }
        #endregion
    }
}
