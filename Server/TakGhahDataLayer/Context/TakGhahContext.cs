using GhorfeDar.DataLayer.Entities.Articles;
using GhorfeDar.DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakGhahDataLayer.Entites.Users;

namespace TakGhahDataLayer.Context
{
    public class TakGhahContext:DbContext
    {
        public TakGhahContext(DbContextOptions<TakGhahContext> options):base(options)
        {
                
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<ArticlesCategory> ArticlesCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
