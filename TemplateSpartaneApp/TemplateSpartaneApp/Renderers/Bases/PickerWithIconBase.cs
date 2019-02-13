using Xamarin.Forms;

namespace TemplateSpartaneApp.Renderers.Bases
{
    public class PickerWithIconBase : Picker
    {
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
        /// Property definition for the <see cref="Icon"/> Property
        /// </summary>
        public static readonly BindableProperty IconProperty =
        BindableProperty.Create(propertyName: nameof(Icon),
              returnType: typeof(string),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: string.Empty);

        /// <summary>
        /// Gets or sets the icon width.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public int IconWidth
        {
            get { return (int)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        /// <summary>
        /// Property definition for the <see cref="IconWidth"/> Property
        /// </summary>
        public static readonly BindableProperty IconWidthProperty =
        BindableProperty.Create(propertyName: nameof(IconWidth),
              returnType: typeof(int),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: 25);

        /// <summary>
        /// Gets or sets the Icon Height.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public int IconHeight
        {
            get { return (int)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        /// <summary>
        /// Property definition for the <see cref="IconHeight"/> Property
        /// </summary>
        public static readonly BindableProperty IconHeightProperty =
        BindableProperty.Create(propertyName: nameof(IconHeight),
              returnType: typeof(int),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: 25);

        /// <summary>
        /// Gets or sets the Border color.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// Property definition for the <see cref="BorderColor"/> Property
        /// </summary>
        public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(propertyName: nameof(BorderColor),
              returnType: typeof(Color),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: Color.Black);

        /// <summary>
        /// Gets or sets the Title color.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public Color TitleColor
        {
            get { return (Color)GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }

        /// <summary>
        /// Property definition for the <see cref="TitleColor"/> Property
        /// </summary>
        public static readonly BindableProperty TitleColorProperty =
        BindableProperty.Create(propertyName: nameof(TitleColor),
              returnType: typeof(Color),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: Color.Black);

        /// <summary>
        /// Gets or sets the Border Width.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        /// <summary>
        /// Property definition for the <see cref="BorderWidth"/> Property
        /// </summary>
        public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(propertyName: nameof(BorderWidth),
              returnType: typeof(int),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: 1);

        /// <summary>
        /// Gets or sets the Corner Radius.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        /// <summary>
        /// Property definition for the <see cref="CornerRadius"/> Property
        /// </summary>
        public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(propertyName: nameof(CornerRadius),
              returnType: typeof(int),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: 4);
    }
}
