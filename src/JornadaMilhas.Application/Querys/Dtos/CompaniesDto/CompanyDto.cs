namespace JornadaMilhas.Application.Querys.Dtos.CompaniesDto;

public record CompanyDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime DtFoundation { get; set; }
}