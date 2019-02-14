using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using TemplateSpartaneApp.LocalData;
using TemplateSpartaneApp.Models.Catalogs;

namespace TemplateSpartaneApp.ViewModels.Session
{
    public class LogInPageViewModel : ViewModelAbstraction
    {
        #region Vars
        private static readonly string TAG = nameof(LogInPageViewModel);
        #endregion

        #region Properties
        private UserSpartaneModel user = new UserSpartaneModel();
        public UserSpartaneModel User
        {
            get => user;
            set => SetProperty( ref user  ,value);
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


        public LogInPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            OnlogInCommand = new DelegateCommand(OnlogInCommandExecute);
        }

        private async void OnlogInCommandExecute()
        {
            if (string.IsNullOrEmpty(User.Email))
            {
                ShowErrorMessage = true;
                ErrorMessage = "*Error Email";
                return;
            }
            else if(string.IsNullOrEmpty(User.Password))
            {
                ShowErrorMessage = true;
                ErrorMessage = "*Error Password";
                return;
            }

            ShowErrorMessage = false;
            Profile.Instance.Email = User.Email;
            Profile.Instance.UserName = User.Password;
            AppSettings.Instance.Logged = true;
            await UserDialogsService.AlertAsync("Welcome !" , "" , "Ok");
           await  NavigationService.NavigateAsync("http://template.com/Index/Navigation/Home");
        }
    }
}
