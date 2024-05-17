using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Util;

public static class JornadaMilhasHelper
{

    public static byte[] ConvertBase64ToByteArray(string base64) => Convert.FromBase64String(base64);
   
}
