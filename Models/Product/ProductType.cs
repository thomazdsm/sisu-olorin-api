using System.ComponentModel.DataAnnotations;

namespace sisu_olorin_api.Models.Product
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
