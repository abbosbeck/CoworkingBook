

using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        //for check
        DbSet<BranchModel> Branches { get; set; }
        DbSet<FloorModel> Floors { get; set; }
        DbSet<TableModel> Tables { get; set; }
        DbSet<BookedTableModel> Bookeds { get; set; }
    }
}