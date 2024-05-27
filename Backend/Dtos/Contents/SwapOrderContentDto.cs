using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Contents
{
    public class SwapOrderContentDto
    {
        [Required]
        public int ContentId1 { get; set; }

        [Required]
        public int ContentId2 { get; set; }
    }
}