using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FishPro.Infraestructure.Persistence
{
    public class FpDbContext : DbContext 
    {
        public FpDbContext(DbContextOptions<FpDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Participation> Participations { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set;}
        public DbSet<User> Users { get; set; }
    }
}
