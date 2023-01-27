using sisu_olorin_api.Models.Profile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisu_olorin_api.Models.Product
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }



        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }
        [ForeignKey("CreatedBy")]
        public User User { get; set; }
    }
}
