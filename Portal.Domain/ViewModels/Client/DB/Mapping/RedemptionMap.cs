using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARMClientPortal.ViewModels.DB.Mapping
{
    public class RedemptionMap : IEntityTypeConfiguration<Redemption>
    {
        public RedemptionMap() { }

        public void Configure(EntityTypeBuilder<Redemption> modelBuilder)
        {
            //Primary Key
            modelBuilder.HasKey(t => t.Id);

            //properties
            //Table & Column Mappings
            modelBuilder.ToTable("Redemption");
            modelBuilder.Property(t => t.Id).HasColumnName("Id");
            modelBuilder.Property(t => t.CustomerReference).HasColumnName("CustomerReference");
            modelBuilder.Property(t => t.RedeemedProducts).HasColumnName("RedeemedProducts");
            modelBuilder.Property(t => t.Amount).HasColumnName("Amount");
            modelBuilder.Property(t => t.Reason).HasColumnName("Reason");
            modelBuilder.Property(t => t.ReasonOther).HasColumnName("ReasonOther");
        }
    }
}
