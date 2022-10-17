using Business_Logic.DTO.BaseDTOs;

namespace Business_Logic.DTO.CommentDTOs
{
    public class CommentCreateDTO : BaseCreateDTO
    {
        public string CommentContent { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
