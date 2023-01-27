using System.ComponentModel.DataAnnotations;

namespace sisu_olorin_api.Models.Profile
{
    public class ProfileType
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
    }
}
