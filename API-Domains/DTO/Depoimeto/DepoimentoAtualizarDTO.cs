using System.ComponentModel.DataAnnotations;

namespace API_Domains.DTO.Depoimeto
{
    public class DepoimentoAtualizarDTO
    {
        [Required]
        public string Nome { get; set; }
        public string DescricaoDepoimento { get; set; }
        public FileStream Foto { get; set; }
    }
}