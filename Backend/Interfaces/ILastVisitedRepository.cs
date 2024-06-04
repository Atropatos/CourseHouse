using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.LastVitited;
using CourseHouse.Models;

namespace Backend.Interfaces
{
    public interface ILastVisitedRepository
    {
        Task<List<LastVisited>> GetAllAsync();
        Task<LastVisited> GetByIdAsync(int id);
        Task<LastVisited> DeleteAsync(int id);
        Task<LastVisited> UpdateAsync(int id, CreateLastVisitedDto updatedLastVisited);
        Task<LastVisited> CreateAsync(LastVisited lastVisited);
        Task<List<LastVisited>> GetLastFiveUserVisits(string userId);
    }
}