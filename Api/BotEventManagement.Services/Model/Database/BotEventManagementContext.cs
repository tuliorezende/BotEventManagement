using BotEventManagement.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace BotEventManagement.Services.Model.Database
{
    public class BotEventManagementContext : DbContext
    {
        public BotEventManagementContext(DbContextOptions<BotEventManagementContext> options) : base(options)
        {
        }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventParticipants> EventParticipants { get; set; }
        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<GuestUserTalks> UserTalks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEvents> UserEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>().OwnsOne(x => x.Address,
                sa =>
                {
                    sa.Property(p => p.Street).HasColumnName("Street");
                    sa.Property(p => p.Latitude).HasColumnName("Latitude");
                    sa.Property(p => p.Longitude).HasColumnName("Longitude");
                });

            modelBuilder.Entity<EventParticipants>().HasKey(x => new { x.GuestId, x.EventId });
            modelBuilder.Entity<EventParticipants>().HasIndex(x => new { x.GuestId, x.EventId });

            modelBuilder.Entity<GuestUserTalks>().HasKey(x => new { x.GuestId, x.ActivityId });
            modelBuilder.Entity<GuestUserTalks>().HasIndex(x => new { x.GuestId, x.ActivityId });

            modelBuilder.Entity<UserEvents>().HasKey(x => new { x.UserId, x.EventId });

            modelBuilder.HasDefaultSchema("BotEventManagement");
            base.OnModelCreating(modelBuilder);
        }
    }
}
