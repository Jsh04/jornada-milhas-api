
namespace JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;

public sealed record DepoimentDto(
    long Id,
    string Name, 
    string DepoimentDescription, 
    byte[] Picture,
    long IdUser
    )
{}



