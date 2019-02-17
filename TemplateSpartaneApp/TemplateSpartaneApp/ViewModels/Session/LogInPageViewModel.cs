using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using TemplateSpartaneApp.ApiServices.Catalogs.SessionService;
using TemplateSpartaneApp.LocalData;
using TemplateSpartaneApp.Models.Catalogs;

namespace TemplateSpartaneApp.ViewModels.Session
{
  public class LogInPageViewModel : ViewModelAbstraction
  {
    #region Vars
    private static readonly string TAG = nameof(LogInPageViewModel);

    private readonly IClientService services;


    #endregion

    #region Properties
    private UserSpartaneModel user = new UserSpartaneModel();
    public UserSpartaneModel User
    {
      get => user;
      set => SetProperty(ref user, value);
    }
    private string errorMessage;
    public string ErrorMessage
    {
      get => errorMessage;
      set => SetProperty(ref errorMessage, value);
    }
    private bool showErrorMessage;
    public bool ShowErrorMessage
    {
      get => showErrorMessage;
      set => SetProperty(ref showErrorMessage, value);
    }

    #endregion

    #region VarsCommand
    public DelegateCommand OnlogInCommand { get; set; }

    #endregion


    public LogInPageViewModel(INavigationService navigationService,
                               IUserDialogs userDialogsService,
                                IClientService ClientServices,
                   IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
    {
      services = ClientServices;

      OnlogInCommand = new DelegateCommand(OnlogInCommandExecute);
    }

    private async void OnlogInCommandExecute()
    {


      if (string.IsNullOrEmpty(User.Email) || string.IsNullOrEmpty(User.Password))
      {
        ShowErrorMessage = true;
        ErrorMessage = "* campos vacios.";
        return;
      }

      var result = await RunSafeApi(services.GetWhereClient(where: $"Correo_Electronico='{User.Email}'"));

      if (result.Status == TypeReponse.Ok && result.Response.Clients != null && result.Response.RowCount > 0)
      {
        var client = result.Response.Clients[0];

        if (client.Contrasena.Equals(User.Password))
        {
          ShowErrorMessage = false;
          Profile.Instance.Identifier = client.Folio;
          Profile.Instance.UserName = client.NombreCompleto;
          Profile.Instance.Phone = client.Celular;
          Profile.Instance.Email = client.CorreoElectronico;
          Profile.Instance.UserName = User.Password;
          AppSettings.Instance.Logged = true;
          await UserDialogsService.AlertAsync("Welcome !", "", "Ok");
          await NavigationService.NavigateAsync("http://template.com/Index/Navigation/Home");
        }
        else
        {
           ShowErrorMessage = true;
          ErrorMessage = "* Contraseña Incorrecta.";
          return;
        }

      }
      else
      {
        ShowErrorMessage = true;
        ErrorMessage = "* Usuario o Contraseña Incorrecta.";
        return;
      }

    }
  }
}
