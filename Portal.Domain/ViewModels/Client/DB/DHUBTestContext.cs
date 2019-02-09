using System;
using ARMClientPortal.ViewModels.DB.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Portal.Domain.ViewModels.Client.DB;

namespace ARMClientPortal.ViewModels.DB
{
    public partial class DHUBTestContext : DbContext
    {
        public DHUBTestContext()
        {
        }

        public DHUBTestContext(DbContextOptions<DHUBTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DirectDebit> DirectDebit { get; set; }
        public virtual DbSet<ProcessPayments> ProcessPayments { get; set; }
        public virtual DbSet<Redemption> Redemption { get; set; }
        public virtual DbSet<DDebit> DDebit { get; set; }
        public virtual DbSet<ClientUpdate> ClientUpdate { get; set; }
        public virtual DbSet<ClientUpdateTemp> ClientUpdateTemp { get; set; }
        public virtual DbSet<PaymentTransactionStatus> PaymentTransactionStatus { get; set; }
        public virtual DbSet<DirectDebitTransactions> DirectDebitTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new DirectDebitMap());
            builder.ApplyConfiguration(new ProcessPaymentsMap());
            builder.ApplyConfiguration(new RedemptionMap());
            builder.ApplyConfiguration(new DDebitMap());
            builder.ApplyConfiguration(new ClientUpdateMap());
            builder.ApplyConfiguration(new ClientUpdateTempMap());
            builder.ApplyConfiguration(new PaymentTransactionStatusMap());
            builder.ApplyConfiguration(new DirectDebitTransactionsMap());
        }
    }
}
