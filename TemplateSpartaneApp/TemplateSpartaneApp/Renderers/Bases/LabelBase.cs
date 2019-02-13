using TemplateSpartaneApp.Models.Bases;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Renderers.Bases
{
    public class LabelBase : Label
    {
        /// <summary>
        /// Property definition for the <see cref="Fonts"/> Property
        /// </summary>
        public static readonly BindableProperty DefineFontProperty =
        BindableProperty.Create(propertyName: nameof(DefineFont),
              returnType: typeof(Fonts),
              declaringType: typeof(LabelBase),
              defaultValue: Fonts.None);

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// The button.
        /// </value>
        public Fonts DefineFont
        {
            get => (Fonts)GetValue(DefineFontProperty);
            set => SetValue(DefineFontProperty, value);
        }

        /// <summary>
        /// Property definition for the <see cref="DefinedColors"/> Property
        /// </summary>
        public static readonly BindableProperty DefineTextColorProperty =
        BindableProperty.Create(propertyName: nameof(DefineTextColor),
              returnType: typeof(DefinedColors),
              declaringType: typeof(LabelBase),
              defaultValue: DefinedColors.None);

        /// <summary>
        /// Gets or sets the define text color.
        /// </summary>
        /// <value>
        /// The button.
        /// </value>
        public DefinedColors DefineTextColor
        {
            get => (DefinedColors)GetValue(DefineTextColorProperty);
            set => SetValue(DefineTextColorProperty, value);
        }
    }
}
