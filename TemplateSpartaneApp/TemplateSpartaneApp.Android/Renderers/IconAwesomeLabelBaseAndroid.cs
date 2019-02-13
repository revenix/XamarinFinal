using Android.Content;
using Android.Graphics;
using Android.Views;
using TemplateSpartaneApp.Droid.Renderers;
using TemplateSpartaneApp.Models.Bases;
using TemplateSpartaneApp.Renderers.Bases;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconAwesomeLabelBase), typeof(IconAwesomeLabelBaseAndroid))]
namespace TemplateSpartaneApp.Droid.Renderers
{
    public class IconAwesomeLabelBaseAndroid : LabelRenderer
    {

        private readonly Context context;

        public IconAwesomeLabelBaseAndroid(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                //Only enable hardware accelleration on lollipop
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(LayerType.Software, null);
                }
            }

            if (!string.IsNullOrEmpty(((IconAwesomeLabelBase)Element).Icon))
            {
                Control.Typeface = Typeface.CreateFromAsset(context.Assets,
                    TemplateSpartaneApp.Extensions.IconExtensions.FindNameFileForFont(((IconAwesomeLabelBase)Element).FontIcon));

                IIcon icon = TemplateSpartaneApp.Extensions.IconExtensions.FindIconForKey(((IconAwesomeLabelBase)Element).Icon);

                Element.Text = $"{icon.Character}";
            }
            else
            {
                Control.Typeface = Typeface.Create(Element.FontFamily, TypefaceStyle.Normal);
                Element.Text = ((IconAwesomeLabelBase)Element).Text;
            }
        }

    }
}