using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models;


namespace DataAccess.Contexts
{
    public class AppDbContext : DbContext { 

        public DbSet<Host> Hosts { get; set; }
        public DbSet<Cpu> Processors { get; set; }

    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
            protected override void OnModelCreating(ModelBuilder builder)
            {
            base.OnModelCreating(builder);
            
            builder.Entity<Host>().ToTable("Hosts");
            builder.Entity<Host>().HasKey(p => p.Id);
            builder.Entity<Host>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Host>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Host>().HasMany(p => p.CpuLoad).WithOne(p => p.Host).HasForeignKey(p => p.HostId);
            builder.Entity<Host>().HasMany(p => p.Users).WithOne(p => p.Host).HasForeignKey(p => p.HostId);
            builder.Entity<Host>().HasMany(p => p.MemoryLoad).WithOne(p => p.Host).HasForeignKey(p => p.HostId); ;






            builder.Entity<Host>().HasData
            (
                new Host { Id = 100, Name = "TestPc", Manufacturer="ASUS",  }
               
            );


            builder.Entity<Processor>().ToTable("Processors");
            builder.Entity<Processor>().HasKey(p => p.Id);
            builder.Entity<Processor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Processor>().Property(p => p.Value).IsRequired().HasMaxLength(10);
            builder.Entity<Processor>().Property(p => p.Type).IsRequired().HasMaxLength(30);
            builder.Entity<Processor>().HasMany(p => p.CpuLoad).WithOne(p => p.Host);


        }



        
    }
}
