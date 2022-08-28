using Exoft_BlogWebAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace Exoft_BlogWebAPI.Services
{
    public class PostServices : ICRUDService<Post>
    {
        DBContext dbContext;

        public PostServices(DBContext _db)
        {
            dbContext = _db;
        }
        public IEnumerable<Post> GetAll()
        {
            return dbContext.Posts;
        }
        public Post GetById(Guid id)
        {
            return (dbContext.Posts.Find(id));
        }
        public void Update(Post post)
        {

            dbContext.Update(post);
            dbContext.SaveChanges();
        }
        public void DeleteById(Guid id)
        {
            if (GetById(id) != null)
            {
                dbContext.Posts.Remove(GetById(id));
                dbContext.SaveChanges();
            }
        }
        public void Post(Post newPost)
        {
            dbContext.Posts.Add(newPost);
            dbContext.SaveChanges();
        }
    }
}
