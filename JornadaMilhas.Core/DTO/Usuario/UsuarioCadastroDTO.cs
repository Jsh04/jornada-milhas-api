
using JornadaMilhas.Core.Indices.Enums;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.DTO.Usuario;

public class UsuarioCadastroDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime DtBirth { get; set; }

    public string Genre { get; set; }

    [Required]
    public string Cpf { get; set; }

    public string Adress { get; set; }

    public string Cep { get; set; }

    public string District { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string State { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }

    [Required]
    [EmailAddress]
    [Compare("Email", ErrorMessage = "Email tem que ser o mesmo que o anterior")]
    public string ConfirmEmail { get; set; }

    [Required]
    [JsonPropertyName("UserRole")]
    public EnumRole Role { get; set; }

    public string CodeEmployee { get; set; }

    [Required]
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
