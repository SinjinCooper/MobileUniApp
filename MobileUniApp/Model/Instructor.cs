using System;
using SQLite;

namespace MobileUniApp
{
    [Table("Instructor")]
    public class Instructor
    {
        [PrimaryKey, AutoIncrement]
        public int? InstructorId { get; set; }
        [MaxLength(250), Unique]
        public string Name { get; set; }
        [MaxLength(250), Unique]
        public string Phone { get; set; }
        [MaxLength(250), Unique]
        public string Email { get; set; }
        [Indexed]
        public int CourseId { get; set; }
    }
}
