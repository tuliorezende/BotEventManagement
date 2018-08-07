using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>().OwnsOne(x => x.Address,
                sa =>
                {
                    sa.Property(p => p.Street).HasColumnName("Street");
                    sa.Property(p => p.Latitude).HasColumnName("Latitude");
                    sa.Property(p => p.Longitude).HasColumnName("Longitude");
                });

            modelBuilder.Entity<EventParticipants>().HasKey(x => new { x.Id, x.EventId });
            modelBuilder.Entity<EventParticipants>().HasIndex(x => new { x.Id, x.EventId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
