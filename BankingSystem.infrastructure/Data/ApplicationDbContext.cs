using BankingSystem.domian.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AuditRecords> AuditRecords { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionTypes> TransactionTypes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => new { ca.AddressID, ca.CustomerID });
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.RoleID, ur.UserID });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            DisableTriggers();
            try
            {
                return base.SaveChanges(acceptAllChangesOnSuccess);
            }
            finally
            {
                EnableTriggers();
            }
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            DisableTriggers();
            try
            {
                return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            finally
            {
                EnableTriggers();
            }
        }

        private void DisableTriggers()
        {
            this.Database.ExecuteSqlRaw("DISABLE TRIGGER ALL ON Accounts");
        }

        private void EnableTriggers()
        {
            this.Database.ExecuteSqlRaw("ENABLE TRIGGER ALL ON Accounts");
        }

    }
}
