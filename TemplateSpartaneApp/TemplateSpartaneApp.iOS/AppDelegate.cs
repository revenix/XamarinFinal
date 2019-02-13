using CarouselView.FormsPlugin.iOS;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using Prism;
using Prism.Ioc;
using TemplateSpartaneApp.DependencyServices;
using TemplateSpartaneApp.iOS.DependencyServices;
using UIKit;


namespace TemplateSpartaneApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            #region Change color status bar
            UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            statusBar.BackgroundColor = UIColor.FromRGB(27, 46, 72);
            var navigationController = new UINavigationController();
            navigationController.NavigationBar.TintColor = UIColor.White;
            navigationController.NavigationBar.BarTintColor = UIColor.FromRGB(52, 152, 219);
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.White
            });
            #endregion
            global::Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            CarouselViewRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            AnimationViewRenderer.Init(); // Initializing Lottie
            LoadApplication(new App(new iOSInitializer()));
            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.Register<ISqlLiteDependecyService, SqlLiteDependecyServiceiOS>();
        }
    }
}
