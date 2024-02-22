using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Indices
{
    public class DepoimentosIndex : ElasticBaseIndex
    {
        public string Nome { get; set; }
        public string DescricaoDepoimento { get; set; }
        public byte[] Foto { get; set; }
    }
}
