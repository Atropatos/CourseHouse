using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesHouse.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly ApplicationDbContext _context;

        public ContentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Content>> GetAllAsync()
        {
            var contents = await _context.content!.ToListAsync();
            return contents;
        }

        public async Task<Content> GetByIdAsync(int id)
        {
            var content = await _context.content!.FindAsync(id);
            return content;
        }

        public async Task<Content> CreateAsync(Content content)
        {
            _context.content!.Add(content);
            await _context.SaveChangesAsync();
            return content;
        }

        public async Task<Content> UpdateAsync(int id, Content updatedContent)
        {
            var existingContent = await _context.content!.FindAsync(id);

            if (existingContent == null)
            {
                return null;
            }

            existingContent.Title = updatedContent.Title;
            existingContent.Text = updatedContent.Text;
            existingContent.ContentUrl = updatedContent.ContentUrl;
            existingContent.Correct = updatedContent.Correct;
            existingContent.ContentType = updatedContent.ContentType;

            await _context.SaveChangesAsync();
            return existingContent;
        }

        public async Task<Content> DeleteAsync(int id)
        {
            var content = await _context.content!.FindAsync(id);
            if (content == null)
            {
                return null;
            }

            _context.content!.Remove(content);
            await _context.SaveChangesAsync();

            return content;
        }

        public async Task<int> GetMaxContentOrder(int courseViewId)
        {
            var maxOrder = await _context.content!
                .Where(cv => cv.CourseViewId == courseViewId)
                .MaxAsync(cv => (int?)cv.Order) ?? 0;
            return maxOrder;
        }

        public async Task ChangeOrderContent(int contentId)
        {
            var selectedContent = await _context.content!.FindAsync(contentId);
            if (selectedContent == null)
            {
                return;
            }

            var currentOrder = selectedContent.Order;

            var courseViewsToUpdate = await _context.content
                .Where(cv => cv.CourseViewId == selectedContent.CourseViewId && cv.Order > currentOrder)
                .ToListAsync();

            foreach (var cv in courseViewsToUpdate)
            {
                cv.Order--;
            }
            selectedContent.Order = await GetMaxContentOrder(selectedContent.ContentId);
            await _context.SaveChangesAsync();
        }
    }
}
