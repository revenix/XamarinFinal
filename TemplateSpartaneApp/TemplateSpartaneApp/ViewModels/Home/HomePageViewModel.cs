using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Navigation; 
using System.Diagnostics;
using System.Drawing;
using TemplateSpartaneApp.ApiServices.Catalogs.SessionService;
using TemplateSpartaneApp.Models.Catalogs;
using Xamarin.Forms;

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
        client.Back = System.Drawing.Color.Red;
      }
      else {
        Client.NombreCompleto = "Seleccionado";
        client.Back = System.Drawing.Color.Yellow;

      }

    }

    #region PopulatingMethods 
    private async void PopulateListView()
    {
      IsBusy = true;
      var result = await RunSafeApi(services.GetWhereClient(0,10));
      if (result.Status == TypeReponse.Ok && result.Response.Clients != null)
      {

        foreach (var  item in result.Response.Clients)
        {
          item.Select = new Command( () => SelectCommandExecute(item));
          item.UpCommand = new Command( ()=> UpCommanddExecute(item.Celular));

        }

        Items.Reset(result.Response.Clients);

      }
      IsBusy = false;

    }

    private void UpCommanddExecute(string celular)
    {
      Debug.WriteLine(" 1 = > Up ComamandExecute");
    }

    private void SelectCommandExecute(ClienteModel item)
    {
      Debug.WriteLine(" 2 = > Up Select ComamandExecute");

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
