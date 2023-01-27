using System.ComponentModel.DataAnnotations;

namespace sisu_olorin_api.Models.Sale
{
    public class SaleStatus
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
