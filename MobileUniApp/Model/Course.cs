using System;
using System.Collections.Generic;
using SQLite;

namespace MobileUniApp
{
    [Table("Course")]
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int? CourseId { get; set; }
        [MaxLength(250), Unique]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Indexed]
        public int TermId { get; set; }
        public string Notes { get; set; }
        [Ignore]
        public Instructor Instructor { get; set; }
        [Ignore]
        public List<Assessment> Assessments { get; set; }

    }
}
