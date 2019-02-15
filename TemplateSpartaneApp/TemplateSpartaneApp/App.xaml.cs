using Acr.UserDialogs;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using SQLite;
using System;
using System.Diagnostics;
using TemplateSpartaneApp.ApiServices.Catalogs.ProgressReport;
using TemplateSpartaneApp.ApiServices.Catalogs.SessionService;
using TemplateSpartaneApp.ApiServices.Catalogs.SpartaneUser;
using TemplateSpartaneApp.ApiServices.Catalogs.SpartanFile;
using TemplateSpartaneApp.DependencyServices;
using TemplateSpartaneApp.LocalData;
using TemplateSpartaneApp.ViewModels;
using TemplateSpartaneApp.ViewModels.Home;
using TemplateSpartaneApp.ViewModels.Session;
using TemplateSpartaneApp.Views;
using TemplateSpartaneApp.Views.Home;
using TemplateSpartaneApp.Views.Session;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TemplateSpartaneApp
{
    public partial class App
    {
        #region Vars
        public static string TAG = nameof(App);
        public static MasterDetailPage Master { get; set; }
        public static App CurrentInstance { get; private set; }
        public static SQLiteConnection SQLiteConnect;
        #endregion

        #region Constructors
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }
        #endregion

        #region Methods Init Prism
        protected override async void OnInitialized()
        {
            InitializeComponent();
            CurrentInstance = this;
            AppSettings.Instance.Initialize(Container.Resolve<ISettings>());
            Profile.Instance.Initialize(Container.Resolve<ISettings>());
            if (AppSettings.Instance.Logged)
            {
                await NavigationService.NavigateAsync(new Uri("http://template.com/Index/Navigation/Home", UriKind.Absolute));
            }
            else {
                await NavigationService.NavigateAsync(new Uri("http://template.com/Navigation/LogIn", UriKind.Absolute));

            }
          //  await NavigationService.NavigateAsync(new Uri("http://template.com/Index/Navigation/Home", UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            #region Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            containerRegistry.RegisterForNavigation<MasterPage, MasterPageViewModel>("Index");
            #endregion

            #region Pages
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>("Home");
            containerRegistry.RegisterForNavigation<HomeBottomBarPage, HomeBottomBarPageViewModel>("HomeBottomBar");
            containerRegistry.RegisterForNavigation<LogInPage,LogInPageViewModel>("LogIn");

            #endregion

            #region Services
            containerRegistry.Register<ISpartaneFileService, SpartanFileService>();
            containerRegistry.Register<IProgressReportService, ProgressReportService>();
            containerRegistry.Register<ISpartaneUserService, SpartaneUserService>();
            containerRegistry.Register<IClienteService , ClientService>();

            #endregion

            #region Instances
            containerRegistry.RegisterInstance(typeof(IUserDialogs), UserDialogs.Instance);
            containerRegistry.RegisterInstance(typeof(IConnectivity), CrossConnectivity.Current);
            containerRegistry.RegisterInstance(typeof(ISettings), CrossSettings.Current);
            containerRegistry.RegisterPopupNavigationService();
            #endregion
        }
        #endregion

        #region Methods
        private void InitServiceSQLite()
        {
            try
            {
                SQLiteConnect = new SQLiteConnection(Container.Resolve<ISqlLiteDependecyService>().GetDatabasePath());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            AppCenter.Start("android=a7839b9a-d131-486e-ae90-dbe36fd632cf;" +
                  "ios=26354eb8-3cea-491d-8242-eb95f64fcbbd;",
                  typeof(Analytics), typeof(Crashes));
        }
        #endregion
    }
}
