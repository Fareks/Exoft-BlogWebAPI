using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserImageRepository : IUserImageRepository   
    {
        private readonly AppDbContext _dbcontext;

        public UserImageRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task UploadImage(UserImage image)
        {
            await _dbcontext.AddAsync(image);
            await _dbcontext.SaveChangesAsync();

        }
    }
}
