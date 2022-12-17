

using Microsoft.EntityFrameworkCore;
using Models;
//using System.Data.Entity;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        DbSet<BranchModel> Branches { get; set; }
        DbSet<FloorModel> Floors { get; set; }
        DbSet<TableModel> Tables { get; set; }
        DbSet<BookedTableModel> Bookeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FloorModel>()
                .HasMany(p => p.Tables)
                .WithOne(p => p.Floor)
                .HasForeignKey(p => p.FloorId);

            modelBuilder.Entity<BranchModel>()
                .HasMany(p => p.Tables)
                .WithOne(p => p.Branch)
                .HasForeignKey(p => p.BranchId);

            modelBuilder.Entity<TableModel>()
                .HasMany(p => p.BookedTables)
                .WithOne(p => p.Table)
                .HasForeignKey(p => p.TableId);

            modelBuilder.Entity<BranchModel>()
                .HasMany(p => p.Floors)
                .WithOne(p => p.Branch)
                .HasForeignKey(p => p.BranchId);

            base.OnModelCreating(modelBuilder);



        }
    }
}