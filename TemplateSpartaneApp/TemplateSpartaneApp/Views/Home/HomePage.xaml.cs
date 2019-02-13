using TemplateSpartaneApp.Renderers.Bases;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.Home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPageBase
	{
		public HomePage ()
		{
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {

                throw;
            }
			
		}
	}
}