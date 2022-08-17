using Microsoft.EntityFrameworkCore;
using Exoft_BlogWebAPI.Models;

namespace Exoft_BlogWebAPI
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
