using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.UserDtos
{
    public class PasswordUpdateDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}