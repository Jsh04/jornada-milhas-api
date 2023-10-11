
using System.ComponentModel.DataAnnotations;

namespace API_Domains.DTO;

public class DepoimentoDTO
{
    [Required]
    public string Nome { get; set; }
    public string DescricaoDepoimento { get; set; }
    public string Foto { get; set; }
}
