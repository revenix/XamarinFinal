using Android.Content;
using Android.Graphics;
using Android.Views;
using TemplateSpartaneApp.Droid.Renderers;
using TemplateSpartaneApp.Renderers.Bases;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LabelBase), typeof(LabelBaseAndroid))]
namespace TemplateSpartaneApp.Droid.Renderers
{
    public class LabelBaseAndroid : LabelRenderer
    {
        private readonly Context context;

        public LabelBaseAndroid(Context context) : base(context)
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
                var font = TemplateSpartaneApp.Extensions.FontExtensions.FindNameFileForFont(((LabelBase)Element).DefineFont);
                if (!string.IsNullOrEmpty(font))
                {
                    Control.Typeface = Typeface.CreateFromAsset(context.Assets, font);
                }

            }
        }

    }
}