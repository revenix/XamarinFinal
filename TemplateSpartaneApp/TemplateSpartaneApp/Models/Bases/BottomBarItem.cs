using Prism.Mvvm;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Models.Bases
{
    public class BottomBarItem : BindableBase
    {
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        private string icon;
        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }
        private ContentView page;
        public ContentView Page
        {
            get => page;
            set => SetProperty(ref page, value);
        }
        private Color titleColor;
        public Color TitleColor
        {
            get => titleColor;
            set => SetProperty(ref titleColor, value);
        }
        private Color iconColor;
        public Color IconColor
        {
            get => iconColor;
            set => SetProperty(ref iconColor, value);
        }
        private int position;
        public int Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }
        private bool select;
        public bool Select
        {
            get => select;
            set => SetProperty(ref select, value);
        }
    }
}
