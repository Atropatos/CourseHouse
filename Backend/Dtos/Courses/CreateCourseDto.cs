namespace CoursesHouse.Dtos.Courses
{
    public class CreateCourseDto
    {
        public string CourseName { get; set; }
        public decimal CoursePrice { get; set; }
        public string CourseDescription { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
