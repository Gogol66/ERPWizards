using ERPWizards.Models.Accounts;
using ERPWizards.Models.Countries;
using ERPWizards.Models.Inventory;
using ERPWizards.Models.Item;
using ERPWizards.Models.Ledger;
using ERPWizards.Models.Measurements;
using ERPWizards.Models.Networking;
using ERPWizards.Models.Settings;
using ERPWizards.Models.States;
using ERPWizards.Models.Time;
using ERPWizards.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ERPWizards.Models
{
    public class ERPDbContext : DbContext
    {
        public ERPDbContext() : base("name=ERPWizardsDB")
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<NetworkModule> NetworkModules { get; set; }
        public DbSet<GlobalStock> GlobalStocks { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<GstDetails> GstDetails { get; set; }
        public DbSet<LedgerGroup> LedgerGroups { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<GeneralLedger> GeneralLedgers { get; set; }
        public DbSet<GstConnectedDetails> GstConnectedDetails { get; set; }
        public DbSet<EInvoiceDetails> EInvoiceDetails { get; set; }
        public DbSet<EWayBillDetails> EWayBillDetails { get; set; }
        public DbSet<TdsDetails> TdsDetails { get; set; }
        public DbSet<TcsDetails> TcsDetails { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<GlobalDataConfig> GlobalDataConfig { get; set; }
        public DbSet<ERPSettings> ERPSettings { get; set; }
        public DbSet<LedgerHead> LedgerHeads { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

        public override int SaveChanges()
        {
            var readOnlyEntities = ChangeTracker.Entries<State>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            if (readOnlyEntities.Any())
            {
                throw new InvalidOperationException("State is read-only and cannot be modified.");
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(c => c.CompanyId);
            modelBuilder.Entity<GstDetails>().HasKey(g => g.GstDetailsId);
            modelBuilder.Entity<GstConnectedDetails>().HasKey(gc => gc.ConnectedDetailsId);
            modelBuilder.Entity<EInvoiceDetails>().HasKey(ei => ei.EInvoiceDetailsId);
            modelBuilder.Entity<EWayBillDetails>().HasKey(ew => ew.EWayBillDetailsId);
            modelBuilder.Entity<TdsDetails>().HasKey(td => td.TdsDetailsId);
            modelBuilder.Entity<TcsDetails>().HasKey(tc => tc.TcsDetailsId);

            modelBuilder.Entity<GstDetails>()
     .HasRequired(g => g.Company)
     .WithMany(c => c.GstDetails)
     .HasForeignKey(g => g.CompanyId);

            modelBuilder.Entity<TdsDetails>()
                .HasRequired(t => t.Company)
                .WithMany(c => c.TdsDetails)
                .HasForeignKey(t => t.CompanyId);

            modelBuilder.Entity<TcsDetails>()
                .HasRequired(t => t.Company)
                .WithMany(c => c.TcsDetails)
                .HasForeignKey(t => t.CompanyId);

            // modelBuilder.Entity<Transaction>()
            //.WithMany(gl => gl.DebitTransactions)
            //.HasForeignKey(t => t.DebitLedgerId)
            //.WillCascadeOnDelete(false);

            // modelBuilder.Entity<Transaction>()
            //     .WithMany(gl => gl.CreditTransactions)
            //     .HasForeignKey(t => t.CreditLedgerId)
            //     .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}












