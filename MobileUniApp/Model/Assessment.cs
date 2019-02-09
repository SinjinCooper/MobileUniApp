using System;
using SQLite;

namespace MobileUniApp
{
    [Table("Assessment")]
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int? AssessmentId { get; set; }
        [MaxLength(250), Unique]
        public string Title { get; set; }
        [MaxLength(250)]
        public string AssessmentType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Indexed]
        public int CourseId { get; set; }
    }
}
