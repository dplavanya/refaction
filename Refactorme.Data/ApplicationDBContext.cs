using Refactoreme.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorme.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductOption> ProductOptions { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            AddEntityInfo();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            AddEntityInfo();
            return base.SaveChangesAsync();
        }

        private void AddEntityInfo()
        {
            var selectedEntityList = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            var currentDateTime = DateTime.Now;

            foreach (var selectedEntity in selectedEntityList)
            {
                if (selectedEntity.State == EntityState.Added)
                {
                    ((EntityInfo)selectedEntity.Entity).CreatedDate = currentDateTime;
                }
                ((EntityInfo)selectedEntity.Entity).ModifiedDate = currentDateTime;
            }
        }

    }
}
