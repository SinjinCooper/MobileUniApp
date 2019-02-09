using System;
//using MobileUniApp.Model;
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

        public void SaveNewItem(Term term)
        {
            try
            {
                conn.Insert(term);
            }
            catch (Exception ex)
            {
                //
            }
        }

        public void SaveNewItem(Course course)
        {
            try
            {
                conn.Insert(course);
            }
            catch (Exception ex)
            {
                //
            }
        }

        public void SaveNewItem(Assessment assessment)
        {
            try {
                conn.Insert(assessment);
            } catch (Exception ex) {
                //
            }
        }
    }
}
