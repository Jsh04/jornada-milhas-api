namespace JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer.InputModels;

public sealed record AddressInputModel(
    string City,
    string State,
    string ZipCode,
    string Address,
    string District)
{
}