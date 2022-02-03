using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BIS.Model.DataModels;

namespace BIS.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        // Table properties e.g
        // public virtual DbSet<Entity> TableName { get; set; }
        public virtual DbSet<BloodGroup> BloodGroups { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<DonorBlood> DonorBloods { get; set; }
        // more properties need to added….
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //configuration commands
            optionsBuilder.UseLazyLoadingProxies(); //enable lazy loading proxies
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API commands
            modelBuilder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>(0);

            modelBuilder.Entity<DonorBlood>()
                .HasKey(sg => new {sg.BloodGroupId, sg.DonorId});

            modelBuilder.Entity<DonorBlood>()
                .HasOne(g => g.BloodGroup)
                .WithMany(sg => sg.DonorBloods)
                .HasForeignKey(g => g.BloodGroupId);

            modelBuilder.Entity<DonorBlood>()
                .HasOne(s => s.Donor)
                .WithMany(sg => sg.DonorBloods)
                .HasForeignKey(s => s.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            /*modelBuilder.Entity<Donor>()
                .HasOne(d => d.Blood)
                .WithOne(b => b.Donor)
                .HasForeignKey<BloodGroup>(b => b.DonorId);*/
        }
    }
}