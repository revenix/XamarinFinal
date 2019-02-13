using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Navigation;

namespace TemplateSpartaneApp.ViewModels.Home
{
    public class HomePageViewModel : ViewModelAbstraction
    {
        public HomePageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            TitleToolbar = "Home";
        }
    }
}
