using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using TemplateSpartaneApp.Droid.Renderers;
using TemplateSpartaneApp.Renderers.Bases;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PickerWithIconBase), typeof(PickerWithIconBaseAndroid))]
namespace TemplateSpartaneApp.Droid.Renderers
{
    public class PickerWithIconBaseAndroid : PickerRenderer
    {

        public PickerWithIconBaseAndroid(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null || Control == null)
                return;

            if (Control != null)
            {
                var view = (PickerWithIconBase)Element;
                Control.ImeOptions = (ImeAction)ImeFlags.NoExtractUi;
                Control.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(view.Icon, view.IconWidth, view.IconHeight), null);
                Control.SetPadding(15, 5, 15, 5);
                Control.Gravity = GravityFlags.Center;
                Control.SetTextColor(view.TextColor.ToAndroid());
                Control.SetTextSize(Android.Util.ComplexUnitType.Sp, (float)view.FontSize);
                Control.SetHintTextColor(view.TitleColor.ToAndroid());
                var _gradientBackground = new GradientDrawable();
                _gradientBackground.SetShape(ShapeType.Rectangle);
                _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                // Thickness of the stroke line  
                _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                // Radius for the curves 
                _gradientBackground.SetCornerRadius(DpToPixels(Context, Convert.ToSingle(view.CornerRadius)));

                Control.SetMaxLines(1);
                Control.SetBackground(_gradientBackground);
                Control.RootView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(nameof(Element.IsEnabled)) && Control != null)
                Control.SetTextColor(Element.TextColor.ToAndroid());
        }

        private BitmapDrawable GetDrawable(string name, int width, int height)
        {
            int resID = Resources.GetIdentifier(name, "drawable", Context.PackageName);
            var drawable = ContextCompat.GetDrawable(Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;
            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, width, height, false));
        }

        private static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }

    }
}