using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using TERP.Entities.Concrete;

namespace TERP.DataAccess.Concrete.EntityFramework.Contexts
{
    public partial class TERPContext : DbContext
    {
        public TERPContext()
            : base("name=TERPContext")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<CostType> CostTypes { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(e => e.Documents)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarType>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.CarType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personal>()
                .HasMany(e => e.Documents)
                .WithRequired(e => e.Personal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Personals)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
