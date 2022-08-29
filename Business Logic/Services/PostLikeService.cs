using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    internal class PostLikeService : ICRUDService<PostLike>
    {
        DBContext dbContext;

        public PostLikeService(DBContext _db)
        {
            dbContext = _db;
        }
        public IEnumerable<PostLike> GetAll()
        {
            return dbContext.PostLike;
        }
        public PostLike GetById(Guid id)
        {
            return (dbContext.PostLike.Find(id));
        }
        public void Update(PostLike post)
        {
            dbContext.Update(post);
            dbContext.SaveChanges();
        }
        public void DeleteById(Guid id)
        {
            if (GetById(id) != null)
            {
                dbContext.PostLike.Remove(GetById(id));
                dbContext.SaveChanges();
            }
        }
        public void Post(PostLike new_postLike)
        {
            dbContext.PostLike.Add(new_postLike);
            dbContext.SaveChanges();
        }
    }
}
