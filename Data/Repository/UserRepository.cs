using Domain.Models;
using Domain.Models.Interface;

namespace Data.Repositorio
{
    public class UserRepository : GenericRepository<User>, IUser
    {
    }
}
