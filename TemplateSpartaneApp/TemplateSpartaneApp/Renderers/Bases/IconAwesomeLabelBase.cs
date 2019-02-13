using TemplateSpartaneApp.Models.Bases;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Renderers.Bases
{
    public class IconAwesomeLabelBase : Label
    {

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
        /// Property definition for the <see cref="Fonts"/> Property
        /// </summary>
        public static readonly BindableProperty FontIconProperty =
        BindableProperty.Create(propertyName: nameof(FontIcon),
              returnType: typeof(Icons),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: Icons.Solid);

        /// <summary>
        /// Property definition for the <see cref="Icon"/> Property
        /// </summary>
        public static readonly BindableProperty IconProperty =
        BindableProperty.Create(propertyName: nameof(Icon),
              returnType: typeof(string),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: string.Empty);

        /// <summary>
        /// Property definition for the <see cref="DefinedColors"/> Property
        /// </summary>
        public static readonly BindableProperty DefineIconColorProperty =
        BindableProperty.Create(propertyName: nameof(DefineIconColor),
              returnType: typeof(DefinedColors),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: DefinedColors.None);

        /// <summary>
        /// Gets or sets the define text color.
        /// </summary>
        /// <value>
        /// The button.
        /// </value>
        public DefinedColors DefineIconColor
        {
            get => (DefinedColors)GetValue(DefineIconColorProperty);
            set => SetValue(DefineIconColorProperty, value);
        }

    }
}
