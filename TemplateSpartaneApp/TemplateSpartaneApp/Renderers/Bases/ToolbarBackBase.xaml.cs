using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Renderers.Bases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarBackBase : ContentView
    {
        public ToolbarBackBase()
        {
            InitializeComponent();
        }
    }
}