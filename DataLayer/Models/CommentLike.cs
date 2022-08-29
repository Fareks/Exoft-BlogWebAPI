namespace DataLayer.Models
{
    public class CommentLike : BaseEntity
    {
        public User User {get;set;}
        public Comment Comment { get; set; }
    }
}
