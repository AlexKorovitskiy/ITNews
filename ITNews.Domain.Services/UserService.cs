using DomainModels.ServiceInterfaces;
using DomainModels.Users;
using ITNews.Data.Contracts.RepositoryInterfaces;
using ITNews.Data.Contracts.Users;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class UserService : AbstractService<UserInfo, User>, IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository repository)
            : base(repository)
        {
            userRepository = repository;
        }

        public UserInfo GetUser(string email, string password)
        {
            var user = userRepository.GetUser()
                .FirstOrDefault(x => x.Email == email && x.Password == password);
            return user != null
                ? AutoMapper.Mapper.Map<UserInfo>(user)
                : null;
        }
    }
}
