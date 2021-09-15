﻿using Microsoft.EntityFrameworkCore;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore
{
    public class PetShopDBContext : DbContext
    {
        public DbSet<InsuranceEntity> Insurance { get; set; }

        public PetShopDBContext(DbContextOptions<PetShopDBContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 1, Name = "AlphaInsurance", Price = 22});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 2, Name = "BetaInsurance", Price = 222});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 3, Name = "GammaInsurance", Price = 2222});
        }
    }
}