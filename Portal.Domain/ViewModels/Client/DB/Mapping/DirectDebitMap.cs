using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARMClientPortal.ViewModels.DB.Mapping
{
    public class DirectDebitMap : IEntityTypeConfiguration<DirectDebit>
    {
        public DirectDebitMap() { }

        public void Configure(EntityTypeBuilder<DirectDebit> modelBuilder)
        {
            //Primary Key
            modelBuilder.HasKey(t => t.Id);

            //properties
            //Table & Column Mappings
            modelBuilder.ToTable("DirectDebit");
            modelBuilder.Property(t => t.Id).HasColumnName("Id");
            modelBuilder.Property(t => t.Action).HasColumnName("Action");
            modelBuilder.Property(t => t.ArmVendorUserName).HasColumnName("ArmVendorUserName");
            modelBuilder.Property(t => t.ArmCustomerId).HasColumnName("ArmCustomerId");
            modelBuilder.Property(t => t.ArmCustomerName).HasColumnName("ArmCustomerName");
            modelBuilder.Property(t => t.ArmDdAmt).HasColumnName("ArmDdAmt");
            modelBuilder.Property(t => t.ArmStartDate).HasColumnName("ArmStartDate");
            modelBuilder.Property(t => t.ArmFrequency).HasColumnName("ArmFrequency");
            modelBuilder.Property(t => t.ArmTranxNotiUrl).HasColumnName("ArmTranxNotiUrl");
            modelBuilder.Property(t => t.ArmPaymentParams).HasColumnName("ArmPaymentParams");
            modelBuilder.Property(t => t.ArmHash).HasColumnName("ArmHash");
        }
    }
}
