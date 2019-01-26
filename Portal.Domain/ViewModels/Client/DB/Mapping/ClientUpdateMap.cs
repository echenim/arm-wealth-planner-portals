using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARMClientPortal.ViewModels.DB.Mapping
{
    public class ClientUpdateMap : IEntityTypeConfiguration<ClientUpdate>
    {
        public ClientUpdateMap() { }

        public void Configure(EntityTypeBuilder<ClientUpdate> modelBuilder)
        {
            //Primary Key
            modelBuilder.HasKey(t => t.Id);

            //properties
            //Table & Column Mappings
            modelBuilder.ToTable("ClientUpdate");
            modelBuilder.Property(t => t.Id).HasColumnName("Id");
            modelBuilder.Property(t => t.MembershipNumber).HasColumnName("MembershipNumber");
            modelBuilder.Property(t => t.Passport).HasColumnName("Passport");
            modelBuilder.Property(t => t.Signature).HasColumnName("Signature");
            modelBuilder.Property(t => t.Thumbprint).HasColumnName("Thumbprint");
            modelBuilder.Property(t => t.ValidID).HasColumnName("ValidID");
            modelBuilder.Property(t => t.TaxNumber).HasColumnName("TaxNumber");
            modelBuilder.Property(t => t.Jurisdiction).HasColumnName("Jurisdiction");
        }
    }
}
