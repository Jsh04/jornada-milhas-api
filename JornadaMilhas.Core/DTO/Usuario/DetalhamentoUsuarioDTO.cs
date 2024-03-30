

using JornadaMilhas.Core.Indices.Enums;

namespace JornadaMilhas.Core.DTO.Usuario;

public class DetalhamentoUsuarioDTO
{
    public long Id { get; set; }

    public string Name { get; set; }

    public DateTime DtBirth { get; set; }

    public EnumGenre Genre { get; set; }

    public EnumRole UserRole { get; set; }

    public string Cpf { get; set; }

    public string Phone { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Email { get; set; }
}
