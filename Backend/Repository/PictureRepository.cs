using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesHouse.Repository
{
    public class PictureRepository: IPictureRepository
    {
        private readonly ApplicationDbContext _context;

        public PictureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Picture>> GetAllAsync()
        {
            return await _context.picture!.ToListAsync();
        }
        public async Task<Picture> CreateAsync(Picture picture)
        {
            await _context.picture.AddAsync(picture);
            await _context.SaveChangesAsync();

            return picture;
        }
    }
}
