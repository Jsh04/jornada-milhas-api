using System.ComponentModel.DataAnnotations;

namespace jornada_milhas.Controllers
{
    public class DepoimentoAtualizarDTO
    {
        [Required]
        public string Nome { get; set; }
        public string DescricaoDepoimento { get; set; }
        public FileStream Foto { get; set; }
    }
}