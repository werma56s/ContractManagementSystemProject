﻿using ContractManagementSystem.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ContractManagementSystem.Core
{
    public class ContractManagementDbContext : DbContext
    {
        public ContractManagementDbContext() : base()
        {

        }
        public ContractManagementDbContext(DbContextOptions<ContractManagementDbContext> options)
       : base(options)
        {
        }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Addendum> Addendums { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ResponsiblePerson> ResponsiblePersons { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0RFC93L;Database=ContractManagementDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure One-to-One relationship between Contract and Category
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Category)
                .WithOne(cat => cat.Contract)
                .HasForeignKey<Contract>(c => c.CategoryId)
                .IsRequired();

            // Configure One-to-Many relationship between Contract and Addendums
            modelBuilder.Entity<Addendum>()
                .HasOne(a => a.Contract)
                .WithMany(c => c.Addendums)
                .HasForeignKey(a => a.ContractId)
                .IsRequired();

            // Configure One-to-Many relationship between Addendum and Product Items
            modelBuilder.Entity<ProductItem>()
                .HasOne(p => p.Addendum)
                .WithMany(a => a.ProductItems)
                .HasForeignKey(p => p.AddendumId)
                .IsRequired();

            // Configure One-to-Many relationship between Addendum and Responsible Persons
            modelBuilder.Entity<ResponsiblePerson>()
                .HasOne(rp => rp.Addendum)
                .WithMany(a => a.ResponsiblePersons)
                .HasForeignKey(rp => rp.AddendumId)
                .IsRequired();
        }
    }
}
