using Android.Content;
using TemplateSpartaneApp.Droid.Renderers;
using TemplateSpartaneApp.Renderers.Bases;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntryBase), typeof(BorderlessEntryBaseAndroid))]
namespace TemplateSpartaneApp.Droid.Renderers
{
    public class BorderlessEntryBaseAndroid : EntryRenderer
    {
        public BorderlessEntryBaseAndroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}