using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Navigation;
using TemplateSpartaneApp.ApiServices.Catalogs.SessionService;

namespace TemplateSpartaneApp.ViewModels.Home
{
    public class HomePageViewModel : ViewModelAbstraction
    {
        private readonly IClienteService services;
        public HomePageViewModel(INavigationService navigationService, 
            IClienteService ClientServices,
            IUserDialogs userDialogsService, 
            IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            services = ClientServices;
            TitleToolbar = "Home";
             
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();
            var test = await services.GetWhereClient();
        }

    }
}
