using TemplateSpartaneApp.Models.Bases;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Renderers.Bases
{
    public class IconAwesomeButtonBase : Button
    {
        /// <summary>
        /// Border Color of circle image
        /// </summary>
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// Border thickness of circle image
        /// </summary>
        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public Icons FontIcon
        {
            get { return (Icons)GetValue(FontIconProperty); }
            set { SetValue(FontIconProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Color property of border
        /// </summary>
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(propertyName: nameof(BorderColor),
              returnType: typeof(Color),
              declaringType: typeof(IconAwesomeButtonBase),
              defaultValue: Color.White);

        /// <summary>
        /// Thickness property of border
        /// </summary>
        public static readonly BindableProperty BorderThicknessProperty =
          BindableProperty.Create(propertyName: nameof(BorderThickness),
              returnType: typeof(int),
              declaringType: typeof(IconAwesomeButtonBase),
              defaultValue: 0);

        /// <summary>
        /// Property definition for the <see cref="Fonts"/> Property
        /// </summary>
        public static readonly BindableProperty FontIconProperty =
        BindableProperty.Create(propertyName: nameof(FontIcon),
              returnType: typeof(Icons),
              declaringType: typeof(IconAwesomeButtonBase),
              defaultValue: Icons.Solid);

        /// <summary>
        /// Property definition for the <see cref="Icon"/> Property
        /// </summary>
        public static readonly BindableProperty IconProperty =
        BindableProperty.Create(propertyName: nameof(Icon),
              returnType: typeof(string),
              declaringType: typeof(IconAwesomeButtonBase),
              defaultValue: string.Empty);
    }
}
