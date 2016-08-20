using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LennyIdentity.Models
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<User> Users { set; get; }

        public DbSet<Role> Roles { set; get; }

        public DbSet<UserRole> UserRoles { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
