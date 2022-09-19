using Business_Logic.DTO.BaseDTOs;

namespace Business_Logic.DTO.CommentDTOs
{
    public class CommentUpdateDTO : BaseUpdateDTO
    {
        public string CommentContent { get; set; }
        public int LikeSnapshot { get; set; }
    }
}
