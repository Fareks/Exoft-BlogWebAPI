using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Comment : BaseEntity
    {   
        [Required]
        [StringLength(150)]
        public string CommentContent { get; set; }
        public int LikeSnapshot { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Post))]
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
