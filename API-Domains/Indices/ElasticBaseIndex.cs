using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestrutura.Indices
{
    public abstract class ElasticBaseIndex
    {
        public string Id { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
