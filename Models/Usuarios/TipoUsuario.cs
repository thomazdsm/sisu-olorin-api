using System.ComponentModel.DataAnnotations;

namespace sisu_olorin_api.Models.Usuarios
{
    public class TipoUsuario
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Tipo { get; set; }
    }
}
