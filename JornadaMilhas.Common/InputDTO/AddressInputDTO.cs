using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.InputDTO;

public sealed record AddressInputDTO(string Address, string District, string City, string State, string ZipCode)
{
}
