using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryModels;
using RepositoryModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base()
        {
        }

        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Section> Sections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ITNews;Trusted_Connection=True;MultipleActiveResultSets=true");
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var role = modelBuilder.Entity<Role>();
            role.HasKey(x => x.Id);
            role.Property(x => x.Name).IsRequired();
            role.HasData(new Role[] {
                new Role(){ Id=1, Name = "admin" },
                new Role(){ Id=2, Name = "writer" },
                new Role(){ Id=3, Name = "reader" }
            });

            var user = modelBuilder.Entity<User>();
            user.HasKey(x => x.Id);
            user.Property(x => x.Name).IsUnicode();
            user.Property(x => x.Password).IsRequired().IsUnicode();
            user.Property(x => x.IsConfirm);
            user.Property(x => x.Email).IsRequired();
            user.HasData(new User[] {
                new User(){ Id = 1, Name = "admin", Email = "a", IsConfirm = true, Password = "a" }
            });

            var userRole = modelBuilder.Entity<UserRole>();
            userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
            userRole.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
            userRole.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
            userRole.HasData(new UserRole[] {
                new UserRole(){ RoleId = 1, UserId = 1 }
            });

            var tag = modelBuilder.Entity<Tag>();
            tag.HasKey(x => x.Id);
            tag.Property(x => x.Name).IsRequired().IsUnicode();

            var section = modelBuilder.Entity<Section>();
            section.HasKey(x => x.Id);
            section.Property(x => x.Name).IsRequired().IsUnicode();
            section.HasData(new Section[] {
                new Section(){ Id = 1, Name="C#"},
                new Section(){ Id = 2, Name=".NET"},
                new Section(){ Id = 3, Name="JAVA"},
                new Section(){ Id = 4, Name="Java Script"},
                new Section(){ Id = 5, Name="Information Technology"},
                new Section(){ Id = 6, Name="SQL"}
            });

            var news = modelBuilder.Entity<News>();
            news.HasKey(x => x.Id);
            news.Property(x => x.Content).IsRequired().IsUnicode();
            news.Property(x => x.Description).IsUnicode().HasMaxLength(200);
            news.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(100);
            news.HasOne(x => x.Author).WithMany(x => x.News).HasForeignKey(x => x.AuthorId);
            news.HasOne(x => x.Section).WithMany(x => x.News).HasForeignKey(x => x.SectionId);

            var newsTag = modelBuilder.Entity<NewsTag>();
            newsTag.HasKey(nt => new { nt.NewsId, nt.TagId });
            newsTag.HasOne(x => x.News).WithMany(x => x.NewsTags).HasForeignKey(x => x.NewsId);
            newsTag.HasOne(x => x.Tag).WithMany(x => x.NewsTags).HasForeignKey(x => x.TagId);
        }
    }
}
