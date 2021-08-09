using AutoMapper;
using Data.Repositorio;
using Domain.Models;
using Domain.Models.Interface;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserServices : IUser
    {
        private UserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(UserRepository userRepository,
                            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task add(User objeto)
        {
            return await _userRepository.add(objeto);
        }

        public async Task<User> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> List(Expression<Func<User, bool>> expression = null, Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null)
        {
            throw new NotImplementedException();
        }

        public async Task Update(User objeto)
        {
            throw new NotImplementedException();
        }
    }
}
