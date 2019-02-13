using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Renderers.ViewCells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GridIVariantItemViewCell : ContentView
	{
		public GridIVariantItemViewCell ()
		{
			InitializeComponent ();
		}
	}
}