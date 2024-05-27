using System;
using Xamarin.Forms;
using ToDo_List_AppMovil_22_1027.iOS;
using System.IO;

[assembly: Dependency(typeof(DatabasePath_iOS))]
namespace ToDo_List_AppMovil_22_1027.iOS
{
    public class DatabasePath_iOS : IDatabasePath
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string libraryPath = Path.Combine(path, "..", "Library");
            return Path.Combine(libraryPath, "todo.db3");
        }
    }
}