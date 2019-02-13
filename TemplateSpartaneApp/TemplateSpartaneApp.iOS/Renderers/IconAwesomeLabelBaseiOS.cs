using System;
using System.ComponentModel;
using System.Diagnostics;
using TemplateSpartaneApp.iOS.Renderers;
using TemplateSpartaneApp.Models.Bases;
using TemplateSpartaneApp.Renderers.Bases;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconAwesomeLabelBase), typeof(IconAwesomeLabelBaseiOS))]
namespace TemplateSpartaneApp.iOS.Renderers
{
    public class IconAwesomeLabelBaseiOS : LabelRenderer
    {

        private static readonly string TAG = nameof(IconAwesomeLabelBaseiOS);

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
            if (Control == null || Element == null)
                return;
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == IconAwesomeLabelBase.IconProperty.PropertyName ||
                e.PropertyName == IconAwesomeLabelBase.TextProperty.PropertyName ||
                e.PropertyName == IconAwesomeLabelBase.FontIconProperty.PropertyName)
            {
                
                if (!String.IsNullOrEmpty(((IconAwesomeLabelBase)Element).Icon))
                {
                    Control.Font = UIFont.FromName(TemplateSpartaneApp.Extensions.IconExtensions.FindNameForFont
                        (((IconAwesomeLabelBase)Element).FontIcon), (nfloat)Element.FontSize);

                    IIcon icon = TemplateSpartaneApp.Extensions.IconExtensions.FindIconForKey(((IconAwesomeLabelBase)Element).Icon);

                    Control.Text = $"{icon.Character}";
                }
            }
        }

    }
}