using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.Core.DTO.Depoimeto
{
    public class DepoimentoAtualizarDTO
    {
        [Required]
        public string Nome { get; set; }
        public string DescricaoDepoimento { get; set; }
        public FileStream Foto { get; set; }
    }
}