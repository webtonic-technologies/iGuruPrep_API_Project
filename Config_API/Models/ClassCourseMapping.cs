namespace Config_API.Models
{
    public class ClassCourseMapping
    {
        public int CourseClassMappingID { get; set; }
        public int? CourseID { get; set; }
        public int? ClassID { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
