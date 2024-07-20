using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.Dtos.UsersDto
{
    public record UserAdminDto : UserDto
    {
        public string CodeEmployee { get; set; }
    }
}
