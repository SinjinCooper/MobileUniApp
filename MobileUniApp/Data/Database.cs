﻿using System;
//using MobileUniApp.Model;
using SQLite;
using System.Collections.Generic;

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


        // TERMS --------------------------------------------------------------//
        public List<Term> GetAllTerms()
        {
            try {
                return conn.Table<Term>().ToList();
            }
            catch (Exception ex) { }
            return new List<Term>();
        }

        public Term GetTermByClassId(string classId)
        {
            try {
                int id = Int32.Parse(classId);
                return conn.Table<Term>().Where(i => i.TermId == id).First();
            }
            catch (Exception ex) { }
            return new Term();
        }


        // COURSES ------------------------------------------------------------//
        public List<Course> GetCoursesByTerm(Term term)
        {
            try {
                return conn.Table<Course>().Where(i => i.TermId == term.TermId).ToList();
            }
            catch (Exception ex) { }
            return new List<Course>();
        }

        public Course GetCourseByClassId(string classId)
        {
            try {
                int id = Int32.Parse(classId);
                return conn.Table<Course>().Where(i => i.CourseId == id).First();
            }
            catch (Exception ex) { }
            return new Course();
        }


        // ASSESSMENTS --------------------------------------------------------//
        public List<Assessment> GetAssessmentsByCourse(Course course)
        {
            try {
                return conn.Table<Assessment>().Where(i => i.CourseId == course.CourseId).ToList();
            }
            catch (Exception ex) { }
            return new List<Assessment>();
        }


        // SAVE NEW ITEM ------------------------------------------------------//
        public void SaveNewItem(Term term)
        {
            try {
                conn.Insert(term);
            }
            catch (Exception ex) { }
        }

        public void SaveNewItem(Course course)
        {
            try {
                conn.Insert(course);
            }
            catch (Exception ex) { }
        }

        public void SaveNewItem(Assessment assessment)
        {
            try {
                conn.Insert(assessment);
            }
            catch (Exception ex) { }
        }

        // EDIT EXISTING ITEM -------------------------------------------------//
        public void EditItem(Term term)
        {

        }

        public void EditItem(Course course)
        {

        }

        public void EditItem(Assessment assessment)
        {

        }
    }
}
