using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BotEventManagement.Services.Model.Database
{
    public class DataProtectionKeysContext : DbContext, IDataProtectionKeyContext
    {
        public DataProtectionKeysContext(DbContextOptions<DataProtectionKeysContext> options):base(options)
        {
        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DataProtection");
            base.OnModelCreating(modelBuilder);
        }
    }
}
