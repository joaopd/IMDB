using Api.DTO;
using AutoMapper;
using Domain.Models;

namespace Api.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            MapUser();
            MapMovie();
            MapEmployee();
            MapImage();
        }

        public void MapUser()
        {
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, UserRegister>().ReverseMap();
        }
        public void MapMovie()
        {
            CreateMap<Movie, GetMoviesDto>().ReverseMap();
            CreateMap<Movie, RegisterMovieDto>().ReverseMap();
        }
        public void MapEmployee()
        {
            CreateMap<Employee, GetMoviesDto>().ReverseMap();
        }
        public void MapImage()
        {
            CreateMap<Image, GetImageDto>().ReverseMap();
            CreateMap<Image, RegisterImageDto>().ReverseMap();
        }
    }
}
