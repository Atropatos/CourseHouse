using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using CourseHouse.Data;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGradeRepository _gradeRepo;
        private readonly UserManager<User> _userManager;

        public GradeController(ApplicationDbContext context, IGradeRepository gradeRepository, UserManager<User> userManager)
        {
            _gradeRepo = gradeRepository;
            _context = context;
            _userManager = userManager;
        }


    }
}