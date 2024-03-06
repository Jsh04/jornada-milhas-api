using JornadaMilhas.Core.Indices.Enums;
using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.Core.Indices;

public class UsuarioIndex : ElasticBaseIndex
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime DtBirth { get; set; }

    public EnumGenre Genre { get; set; }

    [Required]
    public EnumRole UserRole { get; set; }

    [Required]
    public string Cpf { get; set; }

    public string Phone { get; set; }

    public string? CodeEmployee { get; set; }

    public byte[] Picture { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string? Cep { get; set; }

    public string? Adress { get; set; }

    public string? District { get; set; }

    public string Email { get; set; }

    public string ConfirmEmail{ get; set; }

    public string Password { get; set; }

    public bool EmailExists { get; set; }
}
