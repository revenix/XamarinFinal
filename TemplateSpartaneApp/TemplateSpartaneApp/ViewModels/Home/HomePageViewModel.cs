using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Drawing;
using TemplateSpartaneApp.ApiServices.Catalogs.SessionService;
using TemplateSpartaneApp.Models.Catalogs;

namespace TemplateSpartaneApp.ViewModels.Home
{
  public class HomePageViewModel : ViewModelAbstraction
  {


    #region Vars
    private readonly static string TAG = nameof(HomePageViewModel);
    private readonly IClientService services;
    #endregion
    #region Properties

    public ObservableCollectionExt<ClienteModel> Items { get; set; } = new ObservableCollectionExt<ClienteModel>();

    private ClienteModel client;
    public ClienteModel Client
    {
      get => client;
      set {

        SetProperty(ref client, value);

            if (Client != null)
            {
              SelectClient();
            }

      }  

    }

   
    #endregion
    public HomePageViewModel(INavigationService navigationService,
          IClientService Clientservices,
        IUserDialogs userDialogsService,
        IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
    {

      services = Clientservices;

      TitleToolbar = "Home";

    }

    private void SelectClient()
    {

      if (Client.NombreCompleto.Equals("Seleccionado"))
      {
        Client.NombreCompleto = $"'{Client.Nombre} {Client.ApellidoPaterno }'";
        client.Back = Color.Red;
      }
      else {
        Client.NombreCompleto = "Seleccionado";
        client.Back = Color.Yellow;

      }

    }

    #region PopulatingMethods 
    private async void PopulateListView()
    {
      IsBusy = true;
      var result = await RunSafeApi(services.GetWhereClient(0,10));
      if (result.Status == TypeReponse.Ok && result.Response.Clients != null)
      {
        Items.Reset(result.Response.Clients);

      }
      IsBusy = false;

    }

    #endregion

    public override void OnAppearing()
    {
      base.OnAppearing();

      try
      {
        PopulateListView();
      }
      catch (System.Exception ex)
      {
        Debug.WriteLine( ex.Message , TAG);
      }


    }

  }
}
