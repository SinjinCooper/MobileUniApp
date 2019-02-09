using System;
using SQLite;

namespace MobileUniApp.Data
{
    public class Database
    {
        public static SQLiteConnection conn;

        public Database(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Term>();
            conn.CreateTable<Course>();
            conn.CreateTable<Assessment>();
            conn.CreateTable<Instructor>();
        }


    }
}
