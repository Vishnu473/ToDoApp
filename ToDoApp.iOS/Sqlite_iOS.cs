using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using ToDoApp.Model;
using ToDoApp.iOS;

[assembly:Dependency(typeof(Sqlite_iOS))]
namespace ToDoApp.iOS
{
	public class Sqlite_iOS : ISqlLiteConnection
	{
        public SQLiteConnection GetConnection()
        {
            var sqlFileName = "MyDataBBase.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var liraryPath = Path.Combine(documentsPath, "..", "Library");
            var dbPath = Path.Combine(liraryPath, sqlFileName);
            return new SQLiteConnection(dbPath);
        }
    }
}

