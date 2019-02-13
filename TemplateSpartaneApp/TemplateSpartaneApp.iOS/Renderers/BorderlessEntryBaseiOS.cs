using System.ComponentModel;
using TemplateSpartaneApp.iOS.Renderers;
using TemplateSpartaneApp.Renderers.Bases;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEntryBase), typeof(BorderlessEntryBaseiOS))]
namespace TemplateSpartaneApp.iOS.Renderers
{
    public class BorderlessEntryBaseiOS : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}