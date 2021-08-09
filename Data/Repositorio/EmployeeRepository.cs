using Domain.Models;
using Domain.Models.Interface;

namespace Data.Repositorio
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployee
    {
    }
}
