using API_Infraestrutura.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Indices;

public class DestinosIndex : ElasticBaseIndex
{
    public string Name { get; set; }
    public byte[] Picture { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
}
