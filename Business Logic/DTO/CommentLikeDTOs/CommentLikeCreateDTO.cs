using Business_Logic.DTO.BaseDTOs;

namespace Business_Logic.DTO.CommentLikeDTOs
{
    public class CommentLikeCreateDTO : BaseCreateDTO
    {
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
    }
}
