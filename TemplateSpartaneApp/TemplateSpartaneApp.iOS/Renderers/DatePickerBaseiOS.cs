using System;
using TemplateSpartaneApp.iOS.Renderers;
using TemplateSpartaneApp.Renderers.Bases;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DatePickerBase), typeof(DatePickerBaseiOS))]
namespace TemplateSpartaneApp.iOS.Renderers
{
    public class DatePickerBaseiOS : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
                return;
            var element = e.NewElement as DatePickerBase;
            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }
            Control.AdjustsFontSizeToFitWidth = true;
            Control.TextColor = element.TextColor.ToUIColor();
            Control.ShouldEndEditing += (textField) => {
                var seletedDate = (UITextField)textField;
                var text = seletedDate.Text;
                if (text == element.Placeholder)
                {
                    Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                return true;
            };
            if (e.NewElement != null)
            {
                var view = (DatePickerBase)Element;
                // Radius for the curves  
                Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
                // Thickness of the Border Color  
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                // Thickness of the Border Width  
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;
            }
        }
        private void OnCanceled(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }
        private void OnDone(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }
    }
}