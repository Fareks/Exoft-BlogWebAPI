using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        public Task<List<Post>> GetAllByUserId(Guid userId);
        public Task<int> UpdateLikeSnapshot(Guid id);
        public Task<List<Post>> GetAllUnverifiedPosts();
        public Task<List<Post>> GetPostsByCategoryId(Guid categoryId);
        public Task<List<Post>> GetLastPosts(int skip, int take);
        //public Task<IEnumerable<Post>> GetAllLikedPostsByUserId(Guid userId);

    }
}
