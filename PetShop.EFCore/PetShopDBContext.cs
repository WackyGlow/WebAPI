using System;
using Microsoft.EntityFrameworkCore;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore
{
    public class PetShopDBContext : DbContext
    {
        public DbSet<PetEntity> Pet { get; set; } 
        public DbSet<InsuranceEntity> Insurance { get; set; }
        public DbSet<PetTypeEntity> PetType { get; set; }
        public DbSet<OwnerEntity> Owner { get; set; }

        public PetShopDBContext(DbContextOptions<PetShopDBContext> options) : base(options) {}
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>()
                .HasOne(pe => pe.Insurance)
                .WithMany(i => i.pets);
            modelBuilder.Entity<PetEntity>()
                .HasOne(pe => pe.PetType)
                .WithMany(t => t.petsFromType);
            
            //Insurance Seeding
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 1, Name = "AlphaInsurance", Price = 22});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 2, Name = "BetaInsurance", Price = 222});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 3, Name = "GammaInsurance", Price = 2222});
            
            //PetType Seeding
            modelBuilder.Entity<PetTypeEntity>()
                .HasData(new PetTypeEntity() {Id = 1, Name = "Hund"});
            modelBuilder.Entity<PetTypeEntity>()
                .HasData(new PetTypeEntity() {Id = 2, Name = "Kat"});
            modelBuilder.Entity<PetTypeEntity>()
                .HasData(new PetTypeEntity() {Id = 3, Name = "Fisk"});
            
            //Pet Seeding
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity()
                {
                    Id = 1, Name = "Basse", BirthDate = DateTime.Today, Color = "Brown", InsuranceId = 1, PetTypeId = 1,
                    Price = 2000, SoldDate = DateTime.Now
                });
        }
    }
}