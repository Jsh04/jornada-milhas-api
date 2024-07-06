using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Infrastruture.Security;

public interface ITokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claims);
}
