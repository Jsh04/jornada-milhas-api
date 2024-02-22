
using System.Text.RegularExpressions;


namespace JornadaMilhas.Core.Util;

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
