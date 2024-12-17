using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroVeiculos.Dominio.Entidades
{
    public class Administrador
    {
        public Administrador()
        {
        }
        public Administrador(string email, string senha, string perfil)
        {
            Email = email;
            Senha = senha;
            Perfil = perfil;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Senha { get; set; } = default!;

        [Required]
        [StringLength(10)]
        public string Perfil { get; set; } = default!;

    }
}
