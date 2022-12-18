

using Infrastructure.Conficurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
//using System.Data.Entity;

namespace DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        //for check
        public DbSet<BranchModel> Branches { get; set; }
        public DbSet<FloorModel> Floors { get; set; }
        public DbSet<TableModel> Tables { get; set; }
        public DbSet<BookedTableModel> Bookeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FloorModel>()
                .HasMany(p => p.Tables)
                .WithOne(p => p.Floor)
                .HasForeignKey(p => p.FloorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BranchModel>()
                .HasMany(p => p.Tables)
                .WithOne(p => p.Branch)
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<TableModel>()
                .HasMany(p => p.BookedTables)
                .WithOne(p => p.Table)
                .HasForeignKey(p => p.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BranchModel>()
                .HasMany(p => p.Floors)
                .WithOne(p => p.Branch)
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            #region Seed

            modelBuilder.Entity<AppUser>()
                .HasData(new AppUser
                {
                    Id = "1",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@site.com",
                    NormalizedEmail = "ADMIN@SITE.COM",
                    EmailConfirmed = false,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Qwerty123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                });

            #endregion

            //modelBuilder.ApplyConfiguration(new AppUserConfiguration());

            base.OnModelCreating(modelBuilder);



        }
    }
}