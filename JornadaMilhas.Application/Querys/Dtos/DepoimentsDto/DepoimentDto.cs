namespace JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;

public sealed record DepoimentDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string DepoimentDescription { get; set; }
    public long IdUser { get; set; }
}