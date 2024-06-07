using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.LastVitited
{
    public class LastVisitedDto
    {
        public int LastVisitedId { get; set; }
        public string UserId { get; set; }
        public int LastVisitedCourse { get; set; }
    }
}