using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : MasterDetailPage
    {
		public MasterPage ()
		{
			InitializeComponent ();
            App.Master = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}