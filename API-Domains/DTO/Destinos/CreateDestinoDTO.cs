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
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Valor é obrigatório")]
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
