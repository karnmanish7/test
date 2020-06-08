using System.ComponentModel.DataAnnotations;

namespace TaskRobo.Models
{
    public class AppUser
    {
        
        public string UserID { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
