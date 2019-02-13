using System.Collections.Generic;
using System.Linq;
using TemplateSpartaneApp.Models.Bases;
using TemplateSpartaneApp.Renderers.Bases;

namespace TemplateSpartaneApp.Extensions
{
    public static class IconExtensions
    {

        public static Icon DefaultIcon => new Icon("UserCircle", '\uf2bd');

        public static void Add(this IList<IIcon> list, string key, char character) => list.Add(new Icon(key, character));

        public static IIcon FindIconForKey(string iconKey)
        {
            if (string.IsNullOrWhiteSpace(iconKey))
            {
                return DefaultIcon;
            }
            return FontAwesomeCollection.Icons.FirstOrDefault(x => x.Key.Contains(iconKey)) ?? DefaultIcon;
        }

        public static string FindNameFileForFont(Icons font)
        {
            switch (font)
            {
                case Icons.BrandsRegular:
                    return "AwesomeBrandsRegular400.otf";

                case Icons.Regular:
                    return "AwesomeRegular400.otf";

                case Icons.Solid:
                    return "AwesomeSolid900.otf";
                case Icons.Light:
                    return "AwesomeProLight300.otf";
                default:
                    return string.Empty;
            }
        }

        public static string FindNameForFont(Icons font)
        {
            switch (font)
            {
                case Icons.BrandsRegular:
                    return "FontAwesome5FreeBrandsRegular";

                case Icons.Regular:
                    return "FontAwesome5FreeRegular";

                case Icons.Solid:
                    return "FontAwesome5FreeSolid";

                case Icons.Light:
                    return "FontAwesome5ProLight";
                default:
                    return string.Empty;
            }
        }

    }
}
