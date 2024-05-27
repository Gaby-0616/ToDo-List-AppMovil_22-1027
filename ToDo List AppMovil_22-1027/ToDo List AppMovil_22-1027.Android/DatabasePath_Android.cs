using System;
using Xamarin.Forms;
using ToDo_List_AppMovil_22_1027.Droid;
using System.IO;

[assembly: Dependency(typeof(DatabasePath_Android))]
namespace ToDo_List_AppMovil_22_1027.Droid
{
    public class DatabasePath_Android : IDatabasePath
    {
        public string GetDatabasePath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, "todo.db3");
        }
    }
}