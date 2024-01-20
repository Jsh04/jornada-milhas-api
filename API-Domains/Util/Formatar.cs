using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API_Domains.Util;

public static class Formatar
{
    public static string RetirarMascara(string campo)
    {
        if (string.IsNullOrEmpty(campo))
            return string.Empty;

        Regex regex = new (@"\D");
        return regex.Replace(campo, string.Empty);
    }
}
