using System;
using System.ComponentModel;
using System.Diagnostics;
using CoreAnimation;
using CoreGraphics;
using TemplateSpartaneApp.iOS.Renderers;
using TemplateSpartaneApp.Models.Bases;
using TemplateSpartaneApp.Renderers.Bases;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconAwesomeButtonBase), typeof(IconAwesomeButtonBaseiOS))]
namespace TemplateSpartaneApp.iOS.Renderers
{
    public class IconAwesomeButtonBaseiOS : ButtonRenderer
    {

        private static readonly string TAG = nameof(IconAwesomeButtonBaseiOS);

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
                e.PropertyName == IconAwesomeButtonBase.BorderColorProperty.PropertyName ||
                e.PropertyName == IconAwesomeButtonBase.BorderThicknessProperty.PropertyName ||
                e.PropertyName == IconAwesomeButtonBase.IconProperty.PropertyName ||
                e.PropertyName == IconAwesomeButtonBase.TextProperty.PropertyName ||
                e.PropertyName == IconAwesomeButtonBase.FontIconProperty.PropertyName)
            {
                CreateCircle();

                if (!String.IsNullOrEmpty(((IconAwesomeButtonBase)Element).Icon))
                {
                    Control.Font = UIFont.FromName(TemplateSpartaneApp.Extensions.IconExtensions.FindNameForFont
                        (((IconAwesomeButtonBase)Element).FontIcon), (nfloat)Element.FontSize);

                    IIcon icon = TemplateSpartaneApp.Extensions.IconExtensions.FindIconForKey(((IconAwesomeButtonBase)Element).Icon);

                    Control.SetTitle($"{icon.Character}", UIControlState.Normal);
                }
                else
                {
                    Control.Font = Font.OfSize(Element.FontFamily, Element.FontSize).WithAttributes(Element.FontAttributes).ToUIFont();
                    Control.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
                    Control.TitleLabel.TextAlignment = UITextAlignment.Center;
                    Control.SetTitle(((IconAwesomeButtonBase)Element).Text, UIControlState.Normal);
                }
            }
        }

        private void CreateCircle()
        {
            try
            {
                var min = Math.Min(Element.Width, Element.Height);
                Control.Layer.CornerRadius = (nfloat)(min / 2.0);
                Control.Layer.MasksToBounds = false;
                Control.ClipsToBounds = true;

                var borderThickness = ((IconAwesomeButtonBase)Element).BorderThickness;
                var externalBorder = new CALayer();
                externalBorder.CornerRadius = Control.Layer.CornerRadius;
                externalBorder.Frame = new CGRect(-.5, -.5, min + 1, min + 1);
                externalBorder.BorderColor = ((IconAwesomeButtonBase)Element).BorderColor.ToCGColor();
                externalBorder.BorderWidth = ((IconAwesomeButtonBase)Element).BorderThickness;
                Control.Layer.AddSublayer(externalBorder);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to create circle button: " + ex, TAG);
            }
        }

    }
}