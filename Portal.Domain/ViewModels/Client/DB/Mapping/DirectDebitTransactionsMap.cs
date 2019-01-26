using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARMClientPortal.ViewModels.DB.Mapping
{
    public class DirectDebitTransactionsMap : IEntityTypeConfiguration<DirectDebitTransactions>
    {
        public DirectDebitTransactionsMap() { }

        public void Configure(EntityTypeBuilder<DirectDebitTransactions> modelBuilder)
        {
            //Primary Key
            modelBuilder.HasKey(t => t.Id);

            //properties
            //Table & Column Mappings
            modelBuilder.ToTable("DirectDebitTransactions");
            modelBuilder.Property(t => t.Id).HasColumnName("Id");
            modelBuilder.Property(t => t.Action).HasColumnName("Action");
            modelBuilder.Property(t => t.ArmVendorUsername).HasColumnName("VendorUserName");
            modelBuilder.Property(t => t.ArmCustomerId).HasColumnName("CustomerID");
            modelBuilder.Property(t => t.ArmCustomerName).HasColumnName("CustomerName");
            modelBuilder.Property(t => t.ArmDdAmt).HasColumnName("DirectDebitAmount");
            modelBuilder.Property(t => t.ArmStartDate).HasColumnName("StartDate");
            modelBuilder.Property(t => t.ArmFrequency).HasColumnName("Frequency");
            modelBuilder.Property(t => t.ArmDdNotiUrl).HasColumnName("DirectDebitNotiUrl");
            modelBuilder.Property(t => t.ArmPaymentParams).HasColumnName("PaymentParameters");
            modelBuilder.Property(t => t.ArmHash).HasColumnName("Hash");
            modelBuilder.Property(t => t.ArmXmlData).HasColumnName("XmlData");
        }
    }
}
