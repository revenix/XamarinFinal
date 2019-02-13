using TemplateSpartaneApp.Models.Bases;

namespace TemplateSpartaneApp.Extensions
{
    public static class FontExtensions
    {

        public static string FindNameFileForFont(Fonts font)
        {
            switch (font)
            {
                case Fonts.Primary:
                    return "GoogleSans-Regular.ttf";

                case Fonts.Secondary:
                    return "GoogleSans-Medium.ttf";

                default:
                    return string.Empty;
            }
        }

        public static string FindNameForFont(Fonts font)
        {
            switch (font)
            {
                case Fonts.Primary:
                    return "GoogleSans-Regular";

                case Fonts.Secondary:
                    return "GoogleSans-Medium";

                default:
                    return string.Empty;
            }
        }

    }
}
