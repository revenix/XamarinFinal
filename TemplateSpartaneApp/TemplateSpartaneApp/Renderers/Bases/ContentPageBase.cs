using Plugin.DeviceInfo;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace TemplateSpartaneApp.Renderers.Bases
{
    public class ContentPageBase : ContentPage
    {
        private readonly static string TAG = nameof(ContentPageBase);

        public ContentPageBase()
        {
            try
            {
                BackgroundColor = Color.WhiteSmoke;
                Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
                if (CrossDeviceInfo.Current.VersionNumber.Major < 11 && Device.RuntimePlatform.Equals(Device.iOS))
                {
                    Padding = new Thickness(0, 20, 0, 0);
                }
                else
                {
                    On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }
    }
}
