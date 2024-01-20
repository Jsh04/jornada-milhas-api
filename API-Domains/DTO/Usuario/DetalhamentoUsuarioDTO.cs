using API_Domains.Indices.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.DTO.Usuario;

public class DetalhamentoUsuarioDTO
{
    public string Id { get; set; }

    public string Name { get; set; }

    public DateTime DtBirth { get; set; }

    public EnumGenre Genre { get; set; }

    public string Cpf { get; set; }

    public string Phone { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Email { get; set; }
}
