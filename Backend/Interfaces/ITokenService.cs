using CourseHouse.Models;

namespace CoursesHouse.Interfaces
{
    public interface ITokenService
    {

        string CreateToken( User user);
    }
}
