using System;
using System.ComponentModel;
using System.Diagnostics;
using TemplateSpartaneApp.iOS.Renderers;
using TemplateSpartaneApp.Renderers.Bases;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ButtonBase), typeof(ButtonBaseiOS))]
namespace TemplateSpartaneApp.iOS.Renderers
{
    public class ButtonBaseiOS : ButtonRenderer
    {

        private readonly static string TAG = nameof(ButtonBaseiOS);

        protected override void Dispose(bool disposing)
        {
            try
            {
                base.Dispose(disposing);
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control == null || Element == null) return;

            var font = TemplateSpartaneApp.Extensions.FontExtensions.FindNameForFont(((ButtonBase)Element).DefineFont);
            if (!string.IsNullOrEmpty(font))
            {
                Control.Font = UIFont.FromName(font, (nfloat)Element.FontSize);
            }
        }

    }
}