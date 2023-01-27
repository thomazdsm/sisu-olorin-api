using sisu_olorin_api.Models.Profile;
using System.ComponentModel.DataAnnotations;

namespace sisu_olorin_api.Models.Access
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? LastAccess { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
