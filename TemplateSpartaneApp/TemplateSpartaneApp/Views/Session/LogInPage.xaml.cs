using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Renderers.Bases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.Session
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInPage : ContentPageBase
	{
		public LogInPage ()
		{
			InitializeComponent ();
		}
	}
}