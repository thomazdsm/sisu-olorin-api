using sisu_olorin_api.Models.Access;
using System;
using System.ComponentModel.DataAnnotations;

namespace sisu_olorin_api.Models.Profile
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string FullName { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(8)]
        public string? Document { get; set; } = string.Empty;
        public int? PhoneNumber { get; set; } = null;
        public DateTime? BirthDate { get; set; } = null;
        public int? Cep { get; set; } = null;
        [StringLength(200)]
        public string? AddressLine { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;

    }
}
