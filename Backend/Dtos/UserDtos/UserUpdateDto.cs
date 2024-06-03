using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}