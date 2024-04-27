namespace CoursesHouse.Dtos.Course
{
    public class CreateCourseDto
    {
        public string CourseName { get; set; } = string.Empty;


        public decimal CoursePrice { get; set; } = new Decimal(0);
    }
}
