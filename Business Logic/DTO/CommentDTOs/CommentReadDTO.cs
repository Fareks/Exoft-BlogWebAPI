using Business_Logic.DTO.UserDTOs;

namespace Business_Logic.DTO.CommentDTOs
{
    public class CommentReadDTO
    {
        public Guid Id { get; set; }
        public string CommentContent { get; set; }
        public int LikeSnapshot { get; set; }
        public Guid UserId { get; set; }
        public UserReadDTO User { get; set; }
    }
}
