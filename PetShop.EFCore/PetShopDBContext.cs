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

        public PetShopDBContext(DbContextOptions<PetShopDBContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>()
                .HasOne(pe => pe.Insurance)
                .WithMany(i => i.pets);
            modelBuilder.Entity<PetEntity>()
                .HasOne(pe => pe.PetType)
                .WithMany(t => t.petsFromType);
            
            

            //Insurance Seeding

            for (int j = 0; j < 501; j++)
            {
                modelBuilder.Entity<InsuranceEntity>()
                    .HasData(new InsuranceEntity() {Id = j + 1, Name = $"Insurance {j}", Price = j + 1 * 1000});

            }

            //PetType Seeding
                modelBuilder.Entity<PetTypeEntity>()
                    .HasData(new PetTypeEntity() {Id = 1, Name = "Hund"});
                modelBuilder.Entity<PetTypeEntity>()
                    .HasData(new PetTypeEntity() {Id = 2, Name = "Kat"});
                modelBuilder.Entity<PetTypeEntity>()
                    .HasData(new PetTypeEntity() {Id = 3, Name = "Fisk"});

                //Pet Seeding
                for (int i = 0; i < 1000; i++)
                {
                    modelBuilder.Entity<PetEntity>()
                        .HasData(new PetEntity()
                        {
                            Id = i + 1, Name = $"Pet {i}", BirthDate = DateTime.Today, Color = "Brown", InsuranceId = 1,
                            PetTypeId = 1,
                            Price = 2000, SoldDate = DateTime.Now
                        });
                }    

        }
    }
}