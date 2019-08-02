using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models;


namespace DataAccess.Contexts
{
    public class AppDbContext : DbContext { 

        public DbSet<Host> Hosts { get; set; }
        public DbSet<Processor> Processors { get; set; }

    
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
                new Host { Id = 100, Name = "TestPc", Manufacturer="ASUS" }
            );


            builder.Entity<Processor>().ToTable("CPULoad");
            builder.Entity<Processor>().HasKey(p => p.Id);
            builder.Entity<Processor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Processor>().Property(p => p.Value).IsRequired().HasMaxLength(10);
            builder.Entity<Processor>().Property(p => p.Time).IsRequired().HasMaxLength(10);
            builder.Entity<Processor>().HasOne(p=>p.Host).WithMany(p=>p.CpuLoad);

            

            builder.Entity<Memory>().ToTable("MemoryLoad");
            builder.Entity<Memory>().HasKey(p => p.Id);
            builder.Entity<Memory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Memory>().Property(p => p.Value).IsRequired().HasMaxLength(10);
            builder.Entity<Memory>().Property(p => p.Time).IsRequired().HasMaxLength(10);
            builder.Entity<Memory>().HasOne(p => p.Host).WithMany(p => p.MemoryLoad);


            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(10);
            builder.Entity<User>().Property(p => p.Status).IsRequired().HasMaxLength(10);
            builder.Entity<User>().HasOne(p => p.Host).WithMany(p => p.Users);



        }



        
    }
}
