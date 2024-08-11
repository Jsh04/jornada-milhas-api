using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.InputDto;

public sealed record AddressInputDto(string City, string State, string? ZipCode = default, string? Address = default, string? District = default)
{
}
