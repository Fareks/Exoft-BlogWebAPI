namespace Exoft_BlogWebAPI.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
