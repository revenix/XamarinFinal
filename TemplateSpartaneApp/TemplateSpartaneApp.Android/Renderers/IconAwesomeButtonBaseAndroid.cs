using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using TemplateSpartaneApp.Droid.Renderers;
using TemplateSpartaneApp.Models.Bases;
using TemplateSpartaneApp.Renderers.Bases;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconAwesomeButtonBase), typeof(IconAwesomeButtonBaseAndroid))]
namespace TemplateSpartaneApp.Droid.Renderers
{
    public class IconAwesomeButtonBaseAndroid : ButtonRenderer
    {

        private readonly Context context;

        public IconAwesomeButtonBaseAndroid(Context context) : base(context)
        {
            this.context = context;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="child"></param>
        /// <param name="drawingTime"></param>
        /// <returns></returns>
        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        {
            try
            {
                var radius = Math.Min(Width, Height) / 2;

                var borderThickness = (float)((IconAwesomeButtonBase)Element).BorderThickness;

                int strokeWidth = 0;

                if (borderThickness > 0)
                {
                    var logicalDensity = context.Resources.DisplayMetrics.Density;
                    strokeWidth = (int)Math.Ceiling(borderThickness * logicalDensity + .5f);
                }

                radius -= strokeWidth / 2;

                var path = new Path();
                path.AddCircle(Width / 2.0f, Height / 2.0f, radius, Path.Direction.Ccw);

                canvas.Save();
                canvas.ClipPath(path);

                var paint = new Paint();
                paint.AntiAlias = true;
                paint.SetStyle(Paint.Style.Fill);
                canvas.DrawPath(path, paint);
                paint.Dispose();

                var result = base.DrawChild(canvas, child, drawingTime);

                path.Dispose();
                canvas.Restore();

                path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

                if (strokeWidth > 0.0f)
                {
                    paint = new Paint();
                    paint.AntiAlias = true;
                    paint.StrokeWidth = strokeWidth;
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = ((IconAwesomeButtonBase)Element).BorderColor.ToAndroid();
                    canvas.DrawPath(path, paint);
                    paint.Dispose();
                }

                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle button: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
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

            if (!string.IsNullOrEmpty(((IconAwesomeButtonBase)Element).Icon))
            {
                Control.Typeface = Typeface.CreateFromAsset(context.Assets,
                    TemplateSpartaneApp.Extensions.IconExtensions.FindNameFileForFont(((IconAwesomeButtonBase)Element).FontIcon));

                IIcon icon = TemplateSpartaneApp.Extensions.IconExtensions.FindIconForKey(((IconAwesomeButtonBase)Element).Icon);

                Element.Text = $"{icon.Character}";
            }
            else
            {
                Control.Typeface = Typeface.Create(Element.FontFamily, TypefaceStyle.Normal);
                Element.Text = ((IconAwesomeButtonBase)Element).Text;
            }

            if (((IconAwesomeButtonBase)Element).Image != null)
            {
                Android.Widget.Button thisButton = Control as Android.Widget.Button;
                thisButton.Touch += (object sender, Android.Views.View.TouchEventArgs e2) =>
                {
                    if (e2.Event.Action == MotionEventActions.Down)
                    {
                        Control.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
                    }
                    else if (e2.Event.Action == MotionEventActions.Up)
                    {
                        Control.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
                        Control.SetShadowLayer(0, 0, 0, Android.Graphics.Color.Transparent);
                        Control.CallOnClick();
                    }
                };
            }
        }
    }
}