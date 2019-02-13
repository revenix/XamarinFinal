using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Navigation;
using TemplateSpartaneApp.Models.Bases;
using Xamarin.Forms;

namespace TemplateSpartaneApp.ViewModels.Home
{
    public class HomeBottomBarPageViewModel : ViewModelAbstraction
    {

        #region Properties
        public ObservableCollectionExt<BottomBarItem> Items { get; set; }
        #endregion

        public HomeBottomBarPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            TitleToolbar = "Home Bottom Bar";
            Items = new ObservableCollectionExt<BottomBarItem>
            {
                new BottomBarItem {Position=0,Icon="Gamepad", Page = new ContentView{ BackgroundColor = Color.Red } , Title="Test1" },
                new BottomBarItem {Position=1,Icon="Gamepad", Page = new ContentView{ BackgroundColor = Color.Black } , Title="Test1"},
                new BottomBarItem {Position=2,Icon="Gamepad", Page = new ContentView{ BackgroundColor = Color.BlueViolet } , Title="Test1" },
                new BottomBarItem {Position=3,Icon="Gamepad", Page = new ContentView{ BackgroundColor = Color.Accent } , Title="Test1" }
            };
        }
    }
}
