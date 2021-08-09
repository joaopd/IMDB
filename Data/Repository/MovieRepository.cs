using Domain.Models;
using Domain.Models.Interface;

namespace Data.Repositorio
{
    public class MovieRepository : GenericRepository<Movie>, IMovie
    {
    }
}
