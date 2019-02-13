using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Diagnostics;
using TemplateSpartaneApp.Extensions;
using TemplateSpartaneApp.LocalData;

namespace TemplateSpartaneApp.ViewModels
{
    public class MasterPageViewModel : ViewModelAbstraction
    {

        #region Vars
        private static string TAG = nameof(MasterPageViewModel);
        private string currentPage = "Home";
        #endregion

        #region Vars Commands
        public DelegateCommand OnSelectItemCommand { get; set; }
        public DelegateCommand CloseSessionCommand { get; set; }
        #endregion

        #region Properties
        private ObservableCollectionExt<Menu> itemsMenu;
        public ObservableCollectionExt<Menu> ItemsMenu
        {
            get { return itemsMenu; }
            set
            {
                SetProperty(ref itemsMenu, value);
            }

        }
        public Menu selectItem;
        public Menu SelectItem
        {
            get { return selectItem; }
            set
            {
                SetProperty(ref selectItem, value);
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                SetProperty(ref username, value);
            }
        }
        private string imageUser;
        public string ImageUser
        {
            get { return imageUser; }
            set
            {
                SetProperty(ref imageUser, value);
            }
        }
        #endregion

        #region Constructor
        public MasterPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            Username = Profile.Instance.Name;
            ImageUser = "https://loremflickr.com/cache/resized/4873_44297484390_974bb0c13d_z_600_600_nofilter.jpg";
            CreatedMenu();
            OnSelectItemCommand = new DelegateCommand(OnSelectItemCommandExecuted);
            CloseSessionCommand = new DelegateCommand(CloseSessionCommandExecuted);
        }
        #endregion

        #region Methods
        private void CreatedMenu()
        {
            ItemsMenu = new ObservableCollectionExt<Menu>()
            {
                new Menu{ Page= "Home", Title="Rederers Base", Icon= "Gamepad" , PopupPage = true},
                new Menu{ Page= "HomeBottomBar", Title="Home Bottom Bar", Icon="Ticket"},
                new Menu{ Page= "Home", Title="Tablero de Continuidad", Icon="UserCircle"},
                new Menu{ Page= "TiempoReal", Title="Tablero de Tiempo Real", Icon="Bell"},
                new Menu{ Page= "Historicos", Title="Tablero Histórico", Icon="Plus"},
                new Menu{ Page= "Home", Title="Analiticos Gráficas", Icon="PowerOff"},
                new Menu{ Page= "Home", Title="Tableros Dinámicos", Icon="Minus"}
            };
        }
        #endregion

        #region Commands Methods
        private async void OnSelectItemCommandExecuted()
        {
            try
            {
                if (SelectItem != null)
                {
                    if (SelectItem.PopupPage)
                    {
                        await NavigationService.NavigateAsync(new Uri($"{currentPage}/{SelectItem.Page}", UriKind.Relative));
                    }
                    else
                    {
                        currentPage = SelectItem.Page;
                        await NavigationService.NavigateAsync(new Uri($"Navigation/{SelectItem.Page}", UriKind.Relative));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }
        private void CloseSessionCommandExecuted()
        {
            try
            {
                Profile.Instance.ClearValues();
                AppSettings.Instance.ClearValues();
                NavigationService.NavigateAsync(new Uri("http://template.com/Navigation/LogIn", UriKind.Absolute));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }
        public class Menu
        {
            public string Title { get; set; }
            public string Icon { get; set; }
            public string Page { get; set; }
            public bool PopupPage { get; set; }
        }
        #endregion

    }
}
