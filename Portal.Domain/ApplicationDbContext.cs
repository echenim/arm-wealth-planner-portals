using Portal.Domain.Models;
using Portal.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Portal.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>

    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<WhatYouNeedToKNowAboutThisProduct> WhatYouNeedToKNowAboutThisProduct { get; set; }
        public DbSet<TransQIdenfier> TransQIdenfier { get; set; }
        public DbSet<Transactional> Transactional { get; set; }

        #region mark for deletion

        public DbSet<Carts> Carts { get; set; }
        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }

        #endregion mark for deletion

        public DbSet<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }
        public DbSet<ApplicationGroup> ApplicationGroup { get; set; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroup { get; set; }
        public DbSet<ApplicationGroupRole> ApplicationGroupRoles { get; set; }
        public DbSet<Referrer> Referrer { get; set; }
        public DbSet<MemberShip> MemberShip { get; set; }
        public DbSet<ProductInvestmentInfo> ProductInvestmentInfo { get; set; }
        public DbSet<Vouchering> Vouchering { get; set; }

        //client portal
        public DbSet<DDebit> DDebit { get; set; }

        public DbSet<ClientUpdate> ClientUpdate { get; set; }
        public DbSet<ClientUpdateTemp> ClientUpdateTemps { get; set; }
        public DbSet<DirectDebit> DirectDebit { get; set; }
        public DbSet<DirectDebitTransactions> DirectDebitTransactions { get; set; }
        public DbSet<PaymentTransactionStatus> PaymentTransactionStatus { get; set; }
        public DbSet<ProcessPayments> ProcessPayments { get; set; }
        public DbSet<Redemption> Redemptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Manager Unique Identity generator

            builder.HasSequence<long>("DBTransManagerStartFrom10000000000")
                .StartsAt(10000000000)
                .IncrementsBy(1);

            builder.Entity<TransQIdenfier>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEXT VALUE FOR DBTransManagerStartFrom10000000000");

            #endregion Manager Unique Identity generator

            #region apply uniqueness contraints on table  columm

            builder.Entity<Person>().HasIndex(s => s.Email).IsUnique();
            builder.Entity<ProductCategory>().HasIndex(s => s.Name).IsUnique();
            builder.Entity<Products>().HasIndex(s => s.Name).IsUnique();
            builder.Entity<MemberShip>().HasIndex(s => s.Number).IsUnique();

            #endregion apply uniqueness contraints on table  columm

            #region approval process model

            //builder.Entity<WorkflowApprover>(entity =>
            //{
            //    entity.HasOne(d => d.WorkFlowType)
            //   .WithMany(p => p.WorkflowApprovers)
            //   .HasForeignKey(d => d.WorkflowId)
            //   .HasConstraintName("FK_WorkflowApprover_WorkFlowType");
            //});

            //builder.Entity<EfilingSubmission>(entity =>
            //{
            //    entity.HasOne(d => d.EfilingApplicationSection)
            //      .WithMany(d => d.EfilingSubmission)
            //      .HasForeignKey(d => d.EfilingApplicationId)
            //      .HasConstraintName("FK_EfilingSubmission_EfilingApplicationSection");
            //});

            //builder.Entity<ApproverStatusHistory>(entity =>
            //{
            //    entity.HasOne(d => d.WorkFlowSession)
            //   .WithMany(p => p.ApproverStatusHistories)
            //   .HasForeignKey(d => d.WorkFlowSessionId)
            //   .HasConstraintName("FK_ApproverStatusHistory_WorkFlowSession");
            //});

            //builder.Entity<SubmittedDocumentType>(entity =>
            //{
            //    entity.HasOne(d => d.workFlowType)
            //   .WithMany(p => p.SubmittedDocumentTypes)
            //   .HasForeignKey(d => d.WorkFlowTypeId)
            //   .HasConstraintName("FK_SubmittedDocumentType_WorkFlowType");
            //});

            #endregion approval process model

            #region Identiy entities and modification

            builder.Entity<ApplicationUser>().ToTable("AspNetUser");
            builder.Entity<ApplicationUserLogin>().ToTable("AspNetUserLogin");
            builder.Entity<ApplicationRole>().ToTable("AspNetRole");
            builder.Entity<ApplicationUserRole>().ToTable("AspNetUserRole");
            builder.Entity<ApplicationUserClaim>().ToTable("AspNetUserClaim");
            builder.Entity<ApplicationUserToken>().ToTable("AspNetUserToken");
            builder.Entity<ApplicationRoleClaim>().ToTable("AspNetRoleClaim");

            #endregion Identiy entities and modification

            #region modify identity role to be group basepermission

            builder.Entity<ApplicationGroup>()
                .HasMany<ApplicationGroupRole>((ApplicationGroup g) => g.ApplicationRoles)
                .WithOne().IsRequired()
                .HasForeignKey((ApplicationGroupRole g) => g.ApplicationGroupId);
            builder.Entity<ApplicationGroupRole>().ToTable("ApplicationGroupRoles")
                .HasKey((ApplicationGroupRole s) => new
                {
                    ApplicationRoleId = s.ApplicationRoleId,
                    ApplicationGroupId = s.ApplicationGroupId
                });

            builder.Entity<ApplicationGroup>()
                .HasMany<ApplicationUserGroup>((ApplicationGroup g) => g.ApplicationUsers)
                .WithOne().IsRequired()
                .HasForeignKey((ApplicationUserGroup g) => g.ApplicationGroupId);
            builder.Entity<ApplicationUserGroup>().ToTable("ApplicationUserGroups")
                .HasKey((ApplicationUserGroup s) => new
                {
                    ApplicationUserId = s.ApplicationUserId,
                    ApplicationGroupId = s.ApplicationGroupId
                });

            #endregion modify identity role to be group basepermission
        }
    }
}