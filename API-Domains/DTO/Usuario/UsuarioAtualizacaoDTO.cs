using API_Domains.Indices.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.DTO.Usuario;

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
