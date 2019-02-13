using System;
using System.IO;
using TemplateSpartaneApp.DependencyServices;
using TemplateSpartaneApp.Droid.DependencyServices;
using TemplateSpartaneApp.Settings;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlLiteDependecyServiceAndroid))]
namespace TemplateSpartaneApp.Droid.DependencyServices
{
    public class SqlLiteDependecyServiceAndroid : ISqlLiteDependecyService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppConfiguration.Values.NameDB);
        }
    }
}