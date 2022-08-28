namespace Exoft_BlogWebAPI.Models
{
    public class OneToOneSecond
    {
        public int Id { get; set; }
        public OneToOneFirst OneToOneFirst { get; set; }
    }
}
