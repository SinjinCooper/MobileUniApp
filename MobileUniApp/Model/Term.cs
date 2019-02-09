using System;
using System.Collections.Generic;
using SQLite;

namespace MobileUniApp
{
    [Table("Term")]
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int? TermId { get; set; }
        [MaxLength(250), Unique]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        [Ignore]
        public List<Course> Courses { get; set; }
    }
}
