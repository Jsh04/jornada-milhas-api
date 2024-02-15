using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.DTO.Destinos
{
    public class CreateDestinoDTO
    {
        public string Id { get; } = Guid.NewGuid().ToString(); 

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        public double Price { get; set; }

        [Required]
        public string Subtitle { get; set; }

        [Required]
        public string DescriptionPortuguese { get; set; }

        [Required]
        public string DescriptionEnglish { get; set; }

        [Required]
        public List<string> Pictures { get; set; }
    }
}
