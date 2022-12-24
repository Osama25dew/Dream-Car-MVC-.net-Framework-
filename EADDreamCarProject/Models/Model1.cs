using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EADDreamCarProject.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyShowroom> CompanyShowrooms { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Showroom> Showrooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.CarModel)
                .HasForeignKey(e => e.CarModelFID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CarModels)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.CompanyFID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyShowrooms)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.CompanyFID);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.CompanyFID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Showroom>()
                .HasMany(e => e.CompanyShowrooms)
                .WithOptional(e => e.Showroom)
                .HasForeignKey(e => e.ShowroomFID);
        }
    }
}
