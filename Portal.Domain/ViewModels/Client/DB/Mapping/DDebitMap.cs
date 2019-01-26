using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ARMClientPortal.ViewModels.DB.Mapping
{
    public class DDebitMap : IEntityTypeConfiguration<DDebit>
    {
        public DDebitMap() { }

        public void Configure(EntityTypeBuilder<DDebit> modelBuilder)
        {
            //Primary Key
            modelBuilder.HasKey(t => t.Id);

            //properties
            //Table & Column Mappings
            modelBuilder.ToTable("DDebit");
            modelBuilder.Property(t => t.Id).HasColumnName("Id");
            modelBuilder.Property(t => t.DirectDebitReference).HasColumnName("DirectDebitReference");
            modelBuilder.Property(t => t.StatusCode).HasColumnName("StatusCode");
            modelBuilder.Property(t => t.StatusMessage).HasColumnName("StatusMessage");
            modelBuilder.Property(t => t.DebitAmount).HasColumnName("DebitAmount");
            modelBuilder.Property(t => t.CustomerId).HasColumnName("CustomerId");
            modelBuilder.Property(t => t.CardType).HasColumnName("CardType");
            modelBuilder.Property(t => t.CardMask).HasColumnName("CardMask");
            modelBuilder.Property(t => t.AmountApproved).HasColumnName("AmountApproved");
            modelBuilder.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
