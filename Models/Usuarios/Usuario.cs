using System.ComponentModel.DataAnnotations;

namespace sisu_olorin_api.Models.Usuarios
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(11)]
        public string CPF { get; set; }
        [StringLength(8)]
        public string CEP { get; set; } = string.Empty;
        [StringLength(200)]
        public string Endereco_1 { get; set; } = string.Empty;
        [StringLength(200)]
        public string Endereco_2 { get; set; } = string.Empty;
        public TipoUsuario? TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
