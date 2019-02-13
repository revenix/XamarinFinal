using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Navigation;

namespace TemplateSpartaneApp.ViewModels.Session
{
    public class LogInPageViewModel : ViewModelAbstraction
    {
        #region Vars
        private static readonly string TAG = nameof(LogInPageViewModel);
        #endregion
        public LogInPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {

        }
    }
}
