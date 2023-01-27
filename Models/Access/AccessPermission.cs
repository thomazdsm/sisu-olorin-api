using sisu_olorin_api.Models.Profile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisu_olorin_api.Models.Access
{
    public class AccessPermission
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProfileTypeId { get; set; }
        public virtual ProfileType ProfileType { get; set; }
        public int AuthorizedBy { get; set; }
        public DateTime AuthorizedAt { get; set; }

    }
}
