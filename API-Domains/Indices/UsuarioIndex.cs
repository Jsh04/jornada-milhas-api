using API_Domains.Indices.Enums;
using API_Infraestrutura.Indices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Indices;

public class UsuarioIndex : ElasticBaseIndex
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime DtBirth { get; set; }

    public EnumGenre Genre { get; set; }

    [Required]
    public string Cpf { get; set; }

    public string Phone { get; set; }


    public byte[] Picture { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Email { get; set; }

    public string ConfirmEmail{ get; set; }

    public string Password { get; set; }
}
