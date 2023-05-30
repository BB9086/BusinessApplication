using BusinessMobileApi.Models;
using System.Linq;

namespace BusinessMobileApi.Data
{
    public class SQLUserRepo : IUserRepo
    {
        private readonly BusinessDBContext _context;

        public SQLUserRepo(BusinessDBContext context)
        {
            _context = context;
        }

        public User IsUserValid(Credentials credentials)
        {
            return _context.Users.Where(u => u.password == credentials.password && u.username == credentials.username).FirstOrDefault(); 
        }
    }
}
