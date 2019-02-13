using System.Drawing;
using TemplateSpartaneApp.iOS.Renderers;
using TemplateSpartaneApp.Renderers.Bases;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PickerWithIconBase), typeof(PickerWithIconBaseiOS))]
namespace TemplateSpartaneApp.iOS.Renderers
{
    public class PickerWithIconBaseiOS : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var view = (PickerWithIconBase)Element;
                Control.Layer.CornerRadius = view.CornerRadius;
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                Control.TextColor = view.TextColor.ToUIColor();
                Control.TintColor = view.TitleColor.ToUIColor();
                Control.AttributedPlaceholder = new Foundation.NSAttributedString(this.Control.AttributedPlaceholder.Value, foregroundColor: view.TitleColor.ToUIColor());
                Control.Layer.BorderWidth = (float)view.BorderWidth;
                Control.ClipsToBounds = true;
                Control.RightViewMode = UITextFieldViewMode.Always;

                var imageView = new UIImageView(UIImage.FromBundle(view.Icon))
                {
                    // Indent it 10 pixels from the left.
                    Frame = new RectangleF(-5, 0, view.IconWidth, view.IconHeight)
                };

                UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, view.IconWidth, view.IconHeight));
                objLeftView.AddSubview(imageView);
                Control.RightView = objLeftView;
            }
        }
    }
}