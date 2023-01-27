using sisu_olorin_api.Models.Profile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisu_olorin_api.Models.Product
{
    public class ProductSale
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int ProductStatusId { get; set; }
        public int PurchasedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("ProductStatusId")]
        public ProductStatus ProductStatus { get; set; }
        [ForeignKey("PurchasedBy")]
        public User User { get; set; }
    }
}
