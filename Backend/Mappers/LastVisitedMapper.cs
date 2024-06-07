using Backend.Dtos.LastVitited;
using CourseHouse.Models;

namespace Backend.Mappers
{
    public static class LastVisitedMapper
    {
        public static LastVisitedDto ToLastVisitedDto(this LastVisited lastVisited)
        {
            return new LastVisitedDto
            {
                LastVisitedId = lastVisited.LastVisitedId,
                UserId = lastVisited.UserId,
                LastVisitedCourse = lastVisited.LastVisitedCourse
            };
        }

        public static LastVisited ToLastVisitedFromCreateDto(this CreateLastVisitedDto createLastVisitedDto)
        {
            return new LastVisited
            {
                LastVisitedCourse = createLastVisitedDto.LastVisitedCourseId
            };
        }
    }
}
