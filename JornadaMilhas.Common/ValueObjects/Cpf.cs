using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Common.ValueObjects;

public sealed record Cpf
{
    private Cpf(string number)
    {
        Number = number;
    }

    private Cpf()
    {
    }

    public string Number { get; }

    public static Result<Cpf> Create(string number)
    {
        number = FormatCpf(number);

        if (string.IsNullOrWhiteSpace(number))
            return Result.Fail<Cpf>(CpfErrors.CpfIsRequired);

        if (!IsCpf(number))
            return Result.Fail<Cpf>(CpfErrors.CpfIsInvalid);

        var cpf = new Cpf(number);

        return Result<Cpf>.Ok(cpf);
    }

    private static string FormatCpf(string number)
    {
        return number.Trim().Replace(".", "").Replace("-", "");
    }

    private static bool IsCpf(string number)
    {
        int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string cpfTemp;
        string digit;
        var sum = 0;
        int remainder;

        if (number.Length != 11)
            return false;

        cpfTemp = number.Substring(0, 9);

        for (var i = 0; i < 9; i++)
            sum += int.Parse(cpfTemp[i].ToString()) * multiplier1[i];

        remainder = sum % 11;

        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        digit = remainder.ToString();

        cpfTemp += digit;

        sum = 0;

        for (var i = 0; i < 10; i++)
            sum += int.Parse(cpfTemp[i].ToString()) * multiplier2[i];

        remainder = sum % 11;

        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        digit += remainder.ToString();

        return number.EndsWith(digit);
    }

    public sealed record CpfErrors(string Code, string Message, ErrorType Type) : IError
    {
        public static readonly Error CpfIsRequired =
            new("Cpf.CpfIsRequired", "CPF é obrigatório", ErrorType.Validation);

        public static readonly Error CpfIsInvalid =
            new("Cpf.CpfIsInvalid", "CPF não é válido", ErrorType.Validation);
    }
}