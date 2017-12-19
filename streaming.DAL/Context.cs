using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using streaming.DAL.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace streaming.DAL
{

    public class Context : IdentityDbContext<UserDTO, RoleDTO, int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        //public DbSet<UserDTO> Users { get; set; }
        //public DbSet<RoleDTO> Roles { get; set; }
    }
}
