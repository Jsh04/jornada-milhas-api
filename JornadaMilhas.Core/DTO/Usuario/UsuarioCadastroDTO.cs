
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

    public EnumGenre Genre { get; set; }

    public DateTime DtCreated { get; } = DateTime.Now;

    [Required]
    public string Cpf { get; set; }

    public string? Adress { get; set; } = string.Empty;

    public string? Cep { get; set; } = string.Empty;

    public string? District { get; set; } = string.Empty;

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
    [JsonPropertyName("userRole")]
    public EnumRole UserRole { get; set; }

    public string? CodeEmployee { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
