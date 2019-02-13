using System;
using System.IO;
using TemplateSpartaneApp.DependencyServices;
using TemplateSpartaneApp.iOS.DependencyServices;
using TemplateSpartaneApp.Settings;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlLiteDependecyServiceiOS))]
namespace TemplateSpartaneApp.iOS.DependencyServices
{
    public class SqlLiteDependecyServiceiOS : ISqlLiteDependecyService
    {
        public string GetDatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, AppConfiguration.Values.NameDB);
        }
    }
}