using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Collections.Generic;
using BusinessMobileApi.Models;

namespace BusinessMobileApi.Data
{
    public interface IBusinessRepo
    {
        bool SaveChanges();

        IEnumerable<Store> GetAllStores();

        IEnumerable<StoreMonth> GetAllStoreIncomesPerMonth(int id);

        IEnumerable<StoreYear> GetAllStoreIncomesPerYear(int id);

    }
}
