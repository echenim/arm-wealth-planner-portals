using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ARMClientPortal.ViewModels.DB.Mapping
{
    public class ProcessPaymentsMap : IEntityTypeConfiguration<ProcessPayments>
    {
        public ProcessPaymentsMap() { }

        public void Configure(EntityTypeBuilder<ProcessPayments> modelBuilder)
        {
            //Primary Key
            modelBuilder.HasKey(t => t.Id);

            //properties
            //Table & Column Mappings
            modelBuilder.ToTable("ProcessPayments");
            modelBuilder.Property(t => t.Id).HasColumnName("Id");
            modelBuilder.Property(t => t.Action).HasColumnName("Action");
            modelBuilder.Property(t => t.ArmVendorUserName).HasColumnName("ArmVendorUserName");
            modelBuilder.Property(t => t.ArmTranxId).HasColumnName("ArmTranxId");
            modelBuilder.Property(t => t.ArmTranxAmount).HasColumnName("ArmTranxAmount");
            modelBuilder.Property(t => t.ArmCustomerId).HasColumnName("ArmCustomerId");
            modelBuilder.Property(t => t.ArmCustomerName).HasColumnName("ArmCustomerName");
            modelBuilder.Property(t => t.ArmTranxCurr).HasColumnName("ArmTranxCurr");
            modelBuilder.Property(t => t.ArmTranxNotiUrl).HasColumnName("ArmTranxNotiUrl");
            modelBuilder.Property(t => t.ArmXmlData).HasColumnName("ArmXmlData");
            modelBuilder.Property(t => t.ArmPaymentParams).HasColumnName("ArmPaymentParams");
            modelBuilder.Property(t => t.PaymentRequest).HasColumnName("PaymentRequest");
            modelBuilder.Property(t => t.ArmHash).HasColumnName("ArmHash");
        }
    }
}
