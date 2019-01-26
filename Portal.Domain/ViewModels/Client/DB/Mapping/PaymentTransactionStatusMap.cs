using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARMClientPortal.ViewModels.DB.Mapping
{
    public class PaymentTransactionStatusMap : IEntityTypeConfiguration<PaymentTransactionStatus>
    {
        public PaymentTransactionStatusMap() { }

        public void Configure(EntityTypeBuilder<PaymentTransactionStatus> modelBuilder)
        {
            //Primary Key
            modelBuilder.HasKey(t => t.Id);

            //properties
            //Table & Column Mappings
            modelBuilder.ToTable("PaymentTransactionStatus");
            modelBuilder.Property(t => t.Id).HasColumnName("Id");
            modelBuilder.Property(t => t.TransactionReference).HasColumnName("TransactionReference");
            modelBuilder.Property(t => t.PaymentReference).HasColumnName("PaymentReference");
            modelBuilder.Property(t => t.TransactionAmount).HasColumnName("TransactionAmount");
            modelBuilder.Property(t => t.TransactionStatusCode).HasColumnName("TransactionStatusCode");
            modelBuilder.Property(t => t.TransactionStatusMessage).HasColumnName("TransactionStatusMessage");
            modelBuilder.Property(t => t.TransactionCurrency).HasColumnName("TransactionCurrency");
            modelBuilder.Property(t => t.CustomerId).HasColumnName("CustomerId");
            modelBuilder.Property(t => t.PaymentParameters).HasColumnName("PaymentParameters");
        }
    }
}
