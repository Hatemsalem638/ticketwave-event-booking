using Microsoft.EntityFrameworkCore;

namespace soft20181_starter.Models
{
    public class EventsInfoDbContext : DbContext
    {
        public EventsInfoDbContext(DbContextOptions<EventsInfoDbContext> options) : base(options)
        {
        }
        public DbSet<EventList> EventsTable { get; set; }
        public DbSet<SignUpDetails> CutomersDetails { get; set; }
        public DbSet<Messages> CustomersMessages { get; set; }
        public DbSet<AttendaceList> AttendaceTable { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId }); // Define composite primary key

            // Your other entity configurations...

            base.OnModelCreating(modelBuilder);
        }





    }
}
