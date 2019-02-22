using Domain;
using DomainModels;
using DomainModels.News;
using DomainModels.Section;
using DomainModels.ServiceInterfaces;
using DomainModels.Tag;
using DomainModels.Users;
using ITNews.Data.Contracts;
using ITNews.Data.Contracts.Comments;
using ITNews.Data.Contracts.RepositoryInterfaces;
using ITNews.Data.Contracts.Users;
using ITNews.Data.EntityFramework;
using ITNews.Domain.Contracts.Comment;
using ITNews.Domain.Contracts.ServiceInterfaces;
using ITNews.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
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
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ICommentRepository, CommentRepository>();
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
                        y.UserRoles = x.Roles != null //new List<UserRole> { new UserRole { RoleId = 1 } };
                        ? x.Roles.Select(q => new UserRole { RoleId = q.Id, UserId = x.Id }).ToList()
                        : null;
                    });
                config.CreateMap<Role, RoleInfo>();
                config.CreateMap<RoleInfo, Role>();

                config.CreateMap<News, NewsInfo>()
                .AfterMap((source, dest) =>
                {
                    dest.Tags = source.NewsTags.Select(x => new TagInfo { Id = x.TagId, Name = x.Tag.Name, News = null });
                    dest.Comments = source.NewsComments.Select(x => new CommentInfo
                        {
                        NewsId = x.NewsId,
                        Id = x.CommentId,
                        Content = x.Comment.Content,
                        CreatedDate = x.Comment.CreatedDate,
                        AuthorId = x.Comment.AuthorId
                    });
                });
                config.CreateMap<NewsInfo, News>()
                    .ForMember(x => x.NewsTags, s => s.Ignore())
                    .ForMember(x => x.Section, s => s.Ignore())
                    .ForMember(x => x.NewsComments, s => s.Ignore())
                    .AfterMap((source, dest) =>
                    {
                        dest.NewsTags = source.Tags != null
                            ? source.Tags.Select(x => new NewsTag { NewsId = source.Id, TagId = x.Id, Tag = new Tag { Id = x.Id, Name = x.Name } }).ToList()
                            : new List<NewsTag>();
                        /*dest.NewsComments = source.Comments != null
                            ? source.Comments.Select(x=>new NewsComment
                            {
                                NewsId = source.Id,
                                CommentId = source.com
                            })*/
                    });

                config.CreateMap<Tag, TagInfo>();
                config.CreateMap<TagInfo, Tag>();


                config.CreateMap<Section, SectionInfo>();
                config.CreateMap<SectionInfo, Section>();

                config.CreateMap<Comment, CommentInfo>()
                    /*.ForMember(x => x.Id, q => q.MapFrom(w => w.Id))
                    .ForMember(x => x.NewsId, q => q.MapFrom(w => w.NewsComment.NewsId))*/;
                config.CreateMap<CommentInfo, Comment>()
                    .ForMember(x => x.NewsComment, q => q.Ignore())
                    .AfterMap((source, dest) =>
                    {
                        dest.NewsComment = source.NewsId > 0
                        ? new NewsComment { NewsId = source.NewsId, CommentId = source.Id }
                        : null;
                    });
            });
        }
    }
}
