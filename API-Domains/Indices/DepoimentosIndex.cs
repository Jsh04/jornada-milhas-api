using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestrutura.Indices
{
    public class DepoimentosIndex : ElasticBaseIndex
    {
        public string Nome { get; set; }
        public string DescricaoDepoimento { get; set; }
        public FileStream Foto { get; set; }
    }
}
