namespace DataLayer.Models
{
    public class CommentLike : BaseEntity
    {
        [ForeinKey]
        public Guid UserId { get; set; }
        [ForeinKey]
        public Guid CommentId { get; set; }
        public User? User {get;set;}
        public Comment? Comment { get; set; }
    }
}
