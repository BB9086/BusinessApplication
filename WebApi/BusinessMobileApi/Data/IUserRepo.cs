using BusinessMobileApi.Models;

namespace BusinessMobileApi.Data
{
    public interface IUserRepo
    {
        User IsUserValid(Credentials credentials);
    }
}
