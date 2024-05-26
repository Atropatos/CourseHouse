using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesHouse.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly ApplicationDbContext _context;
        // private readonly IContentRepository _contentRepo;
        // private readonly UserManager<User> _userManager;
        private readonly ILogger<ContentRepository> _logger;
        public ContentRepository(ApplicationDbContext context, ILogger<ContentRepository> logger)
        {
            _context = context;
            _logger = logger;
            //  _contentRepo = contentRepository;
            //  _userManager = userManager;
        }

        public async Task<Content> CreateAsync(Content content)
        {

            await _context.content.AddAsync(content);
            await _context.SaveChangesAsync();
            return content;

        }
        public async Task<List<Content>> getAllAsync()
        {
            //return await _context.content?.Include(a => a.Author).ToListAsync();
            return await _context.content!
              .Include(c => c.CourseView)
              .ToListAsync();
        }
    }
}
