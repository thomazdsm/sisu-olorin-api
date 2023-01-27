using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using sisu_olorin_api.Models.Product;
using sisu_olorin_api.Models.Profile;

namespace sisu_olorin_api.Models.Sale
{
    public class SaleTracking
    {
        [Key]
        public int Id { get; set; }
        public int ProductSaleId { get; set; }
        public int SaleStatusId { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }


        [ForeignKey("ProductSaleId")]
        public ProductSale ProductSale { get; set; }
        [ForeignKey("SaleStatusId")]
        public SaleStatus SaleStatus { get; set; }
        [ForeignKey("UpdatedBy")]
        public User User { get; set; }
    }
}
