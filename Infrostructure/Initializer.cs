﻿using Domain;
using DomainModels;
using DomainModels.News;
using DomainModels.ServiceInterfaces;
using DomainModels.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using RepositoryModels;
using RepositoryModels.RepositoryInterfaces;
using RepositoryModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrostructure
{
    public static class Initializer
    {
        public static void Initialize(this IServiceCollection services, IConfiguration configuration)
        {
            //var vonnectionString = configurationp[];
            //services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            services.InitializeAutoMapper();
            services.InitializeDependensies();
        }

        public static void InitializeDependensies(this IServiceCollection services)
        {

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<INewsRepository, NewsRepository>();
            //services.AddTransient<IEntityRepository<Role>, RoleInfo>();
        }

        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<User, UserInfo>()
                    .ForMember(x => x.Roles, q => q.Ignore())
                    .AfterMap((x, w) =>
                    {
                        w.Roles = x.UserRoles != null
                        ? x.UserRoles.Where(q => q.Role != null).Select(q => new RoleInfo { Id = q.Role.Id, Name = q.Role.Name })
                        : null;
                    });
                config.CreateMap<UserInfo, User>()
                    .ForMember(x => x.UserRoles, q => q.Ignore())
                    .AfterMap((x, y) =>
                    {
                        y.UserRoles = new List<UserRole> { new UserRole { RoleId = 1 } };/*x.Roles != null
                        ? x.Roles.Select(q => new UserRole { RoleId = q.Id })
                        : null;*/
                    });
                config.CreateMap<Role, RoleInfo>();
                config.CreateMap<RoleInfo, Role>();

                config.CreateMap<News, NewsInfo>();
                //.ForMember(x=>x.);
                config.CreateMap<NewsInfo, News>();
            });
        }
    }
}
