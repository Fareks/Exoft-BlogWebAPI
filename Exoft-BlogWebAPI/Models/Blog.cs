using System.ComponentModel.DataAnnotations.Schema;

namespace Exoft_BlogWebAPI.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string TextContent { get; set; }
        public string LikeSnapshot { get; set; }
        public bool VerifyStatus { get; set; }
        public DateTime Created { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
