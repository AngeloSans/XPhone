using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using XPhone.Domain.Entities;


namespace XPhone.Infrastructure
{
    public class XPhoneDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<SmartPhone> SmartPhones { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public XPhoneDbContext(DbContextOptions<XPhoneDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Rents)
                .WithOne(r => r.Client)
                .HasForeignKey(r => r.ClientId);

            modelBuilder.Entity<SmartPhone>()
                .HasMany(s => s.Rents)
                .WithOne(r => r.SmartPhone)
                .HasForeignKey(r => r.SmartPhoneId);

            modelBuilder.Entity<Stock>()
                .HasMany(s => s.Phones)
                .WithOne(p => p.Stock)
                .HasForeignKey(p => p.StockId);

            modelBuilder.Entity<Rent>()
                .HasOne(r => r.Return)
                .WithOne(ret => ret.Rent)
                .HasForeignKey<Return>(ret => ret.RentId);
        }
    }
}
