using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.LastVitited;
using Backend.Interfaces;
using CourseHouse.Data;
using CourseHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class LastVisitedRepository : ILastVisitedRepository
    {
        private readonly ApplicationDbContext _context;

        public LastVisitedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LastVisited> CreateAsync(LastVisited lastVisited)
        {
            var existingVisit = await _context.lastVisited.FirstOrDefaultAsync(lv => lv.UserId == lastVisited.UserId && lv.LastVisitedCourse == lastVisited.LastVisitedCourse);

            if(existingVisit != null )
            {
                //existingVisit.LastVisitedId = lastVisited.LastVisitedId;
                _context.lastVisited.Update(existingVisit);
            }
            else
            {
                _context.lastVisited!.Add(lastVisited);
            }

            await _context.SaveChangesAsync();
            return lastVisited;
        }

        public async Task<LastVisited> DeleteAsync(int id)
        {
            var lastVisited = await _context.lastVisited!.FindAsync(id);
            if (lastVisited == null)
            {
                return null;
            }

            _context.lastVisited!.Remove(lastVisited);
            await _context.SaveChangesAsync();

            return lastVisited;
        }

        public async Task<List<LastVisited>> GetAllAsync()
        {
            return await _context.lastVisited!.ToListAsync();
        }

        public async Task<LastVisited> GetByIdAsync(int id)
        {
            return await _context.lastVisited!.FindAsync(id);
        }

        public async Task<LastVisited> UpdateAsync(int id, CreateLastVisitedDto updatedLastVisited)
        {
            var lastVisited = await _context.lastVisited!.FindAsync(id);
            if (lastVisited == null)
            {
                return null;
            }

            lastVisited.LastVisitedCourse = updatedLastVisited.LastVisitedCourseId;

            await _context.SaveChangesAsync();
            return lastVisited;
        }

        public async Task<List<LastVisited>> GetLastFiveUserVisits(string userId)
        {
            var lastVisitedItems = await _context.lastVisited!
                .Where(x => x.UserId == userId)
                .OrderByDescending(lv => lv.LastVisitedId)
                .Take(5)
                .ToListAsync();

            return lastVisitedItems;
        }

        public async Task<int> GetVisitCountByCourseIdAsync(int courseId)
        {
            return await _context.lastVisited!.CountAsync(lv => lv.LastVisitedCourse == courseId);
        }
    }
}
