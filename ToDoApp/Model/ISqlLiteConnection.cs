using System;
using SQLite;

namespace ToDoApp.Model
{
    public interface ISqlLiteConnection
    {
        SQLiteConnection GetConnection();

    }
}

