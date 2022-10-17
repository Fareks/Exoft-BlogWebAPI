using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public CategoryImage? CategoryImage { get; set; }
    }
}
