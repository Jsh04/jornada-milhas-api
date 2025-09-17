using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Admins.Enums;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Users;

namespace JornadaMilhas.Core.Entities.Admins;

public class Admin : User
{
    public virtual Company Company { get; }

    public long CompanyId { get; }

    public decimal Salary { get; }

    public EnumPosition Position { get; }

    public Admin(AdminBuilder builder) : base(
        builder.Name,
        builder.DtBirth,
        builder.Genre,
        builder.Cpf,
        builder.Phone,
        builder.Address,
        builder.Mail,
        builder.ConfirmMail,
        builder.Password)
    {
        Position = builder.Position;
        Company = builder.Company;
        Salary = builder.Salary;
    }

    private Admin(): base() { }
}