namespace JornadaMilhas.Common.InputDto;

public sealed record AddressInputDto(string City, string State, string? ZipCode = default, string? Address = default, string? District = default)
{
}
