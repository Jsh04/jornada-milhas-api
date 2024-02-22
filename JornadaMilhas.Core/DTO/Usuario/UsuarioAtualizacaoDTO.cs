
using JornadaMilhas.Core.Indices.Enums;

using System.ComponentModel.DataAnnotations;


namespace JornadaMilhas.Core.DTO.Usuario;

public class UsuarioAtualizacaoDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime DtBirth { get; set; }

    public EnumGenre Genre { get; set; }
    [Required]
    public string Cpf { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required] 
    public FileStream Picture {  get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string State { get; set; }


}
