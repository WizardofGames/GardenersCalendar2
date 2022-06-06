using GardenersCalendar2.Data.EFClasses;
using GardenersCalendar2.Data.GardenerUserNS;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GardenersCalendar2.Data
{
    public class ApplicationDbContext : IdentityDbContext<GardenerUserClass>
    {
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<Nursery> Nurseries { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}