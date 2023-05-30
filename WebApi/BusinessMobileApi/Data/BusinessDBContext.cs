using BusinessMobileApi.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BusinessMobileApi.Data
{
    public class BusinessDBContext:DbContext
    {
        public BusinessDBContext(DbContextOptions<BusinessDBContext> opt) : base(opt)
        {

        }

        public DbSet<Store> Stores { get; set; }

        public DbSet<StoreMonth> StoreIncomePerMonths { get; set; }

        public DbSet<StoreYear> StoreIncomePerYears { get; set; }

        public DbSet<User>  Users { get; set; }
    }
}
