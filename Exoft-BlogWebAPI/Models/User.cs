using System.ComponentModel.DataAnnotations.Schema;

namespace Exoft_BlogWebAPI.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Blog>? Blog { get; set; }

    }
}
