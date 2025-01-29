namespace JornadaMilhas.Common.InputModels;

public sealed record AddressInputModel(
    string City,
    string State,
    string ZipCode,
    string Address,
    string District)
{
}