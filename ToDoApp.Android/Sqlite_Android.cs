using System;
using System.IO;
using SQLite;
using ToDoApp.Droid;
using ToDoApp.Model;
using Xamarin.Forms;

[assembly:Dependency(typeof(Sqlite_Android))]
namespace ToDoApp.Droid
{
	public class Sqlite_Android : ISqlLiteConnection
	{
        public SQLiteConnection GetConnection()
        {
            var sqlFileName = "MyDatabase.db3";
            var FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(FilePath, sqlFileName);
            return new SQLiteConnection(dbPath);
        }
    }
}

