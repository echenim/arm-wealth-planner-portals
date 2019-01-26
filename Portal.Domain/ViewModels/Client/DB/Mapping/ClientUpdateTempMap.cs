using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARMClientPortal.ViewModels.DB.Mapping
{
    public class ClientUpdateTempMap : IEntityTypeConfiguration<ClientUpdateTemp>
    {
        public ClientUpdateTempMap() { }

        public void Configure(EntityTypeBuilder<ClientUpdateTemp> modelBuilder)
        {
            //Primary Key
            modelBuilder.HasKey(t => t.Id);

            //properties
            //Table & Column Mappings
            modelBuilder.ToTable("ClientUpdateTemp");
            modelBuilder.Property(t => t.Id).HasColumnName("Id");
            modelBuilder.Property(t => t.MembershipNumber).HasColumnName("MembershipNumber");
            modelBuilder.Property(t => t.ProgressStatus).HasColumnName("ProgressStatus");
            modelBuilder.Property(t => t.EvaluationStatus).HasColumnName("EvaluationStatus");
            modelBuilder.Property(t => t.Passport).HasColumnName("Passport");
            modelBuilder.Property(t => t.Signature).HasColumnName("Signature");
            modelBuilder.Property(t => t.Thumbprint).HasColumnName("Thumbprint");
            modelBuilder.Property(t => t.ValidID).HasColumnName("ValidID");
            modelBuilder.Property(t => t.TaxNumber).HasColumnName("TaxNumber");
            modelBuilder.Property(t => t.Jurisdiction).HasColumnName("Jurisdiction");
            modelBuilder.Property(t => t.IsKYCApproved).HasColumnName("IsKYCApproved");
            modelBuilder.Property(t => t.IsPassportApproved).HasColumnName("IsPassportApproved");
            modelBuilder.Property(t => t.IsSignatureApproved).HasColumnName("IsSignatureApproved");
            modelBuilder.Property(t => t.IsThumbprintApproved).HasColumnName("IsThumbprintApproved");
            modelBuilder.Property(t => t.IsValidIdApproved).HasColumnName("IsValidIdApproved");
            modelBuilder.Property(t => t.DateUpdated).HasColumnName("DateUpdated");
        }
    }
}
