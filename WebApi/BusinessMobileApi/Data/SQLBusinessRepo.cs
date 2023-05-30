using BusinessMobileApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessMobileApi.Data
{
    public class SQLBusinessRepo : IBusinessRepo
    {

        private readonly BusinessDBContext _context;

        public SQLBusinessRepo(BusinessDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Store> GetAllStores()
        {
            return _context.Stores.ToList();
        }
        public IEnumerable<StoreMonth> GetAllStoreIncomesPerMonth(int id)
        {
            return _context.StoreIncomePerMonths.Where(x => x.number == id).ToList();
        }
        public IEnumerable<StoreYear> GetAllStoreIncomesPerYear(int id)
        {
            return _context.StoreIncomePerYears.Where(x=>x.number == id).ToList();
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
