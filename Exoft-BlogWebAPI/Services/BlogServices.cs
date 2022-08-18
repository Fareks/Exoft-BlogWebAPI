using Exoft_BlogWebAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace Exoft_BlogWebAPI.Services
{
    public class BlogServices : ICRUDService<Blog>
    {
        DBContext dbContext;

        public BlogServices(DBContext _db)
        {
            dbContext = _db;
        }
        public IEnumerable<Blog> GetAll()
        {
            return dbContext.Blogs;
        }
        public Blog GetById(int id)
        {
            return (dbContext.Blogs.Find(id));
        }
        public void Update(Blog blog)
        {
            dbContext.Update(blog);
            dbContext.SaveChanges();
        }
        public void DeleteById(int id)
        {
            if (GetById(id) != null)
            {
                dbContext.Blogs.Remove(GetById(id));
                dbContext.SaveChanges();
            }
        }
        public void Post(Blog newBlog)
        {
            dbContext.Blogs.Add(newBlog);
            dbContext.SaveChanges();
        }
    }
}
