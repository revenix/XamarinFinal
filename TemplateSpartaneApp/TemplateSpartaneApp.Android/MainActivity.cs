using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using Plugin.CurrentActivity;
using Prism;
using Prism.Ioc;
using TemplateSpartaneApp.DependencyServices;
using TemplateSpartaneApp.Droid.DependencyServices;

namespace TemplateSpartaneApp.Droid
{
    [Activity(Label = "TemplateSpartaneApp", Icon = "@mipmap/ic_launcher", Theme = "@style/Theme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            UserDialogs.Init(this);
            CrossCurrentActivity.Current.Init(this, bundle);
            CarouselViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            LoadApplication(new App(new AndroidInitializer()));
        }
        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                // Do something if there are some pages in the `PopupStack`
            }
            else
            {
                // Do something if there are not any pages in the `PopupStack`
            }
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.Register<ISqlLiteDependecyService, SqlLiteDependecyServiceAndroid>();
        }
    }
}

