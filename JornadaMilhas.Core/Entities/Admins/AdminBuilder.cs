using JornadaMilhas.Common.Builder;
using JornadaMilhas.Core.Entities.Admins.Enums;
using JornadaMilhas.Core.Entities.Companies;

namespace JornadaMilhas.Core.Entities.Admins;

public class AdminBuilder : UserBuilder<Admin, AdminBuilder>
{
    public EnumPosition Position { get; private set; }

    public decimal Salary { get; private set; }
    
    public Company Company { get; private set; }

    
    public AdminBuilder WithSalary(decimal salary)
    {
        Salary = salary;
        return this;
    }
    
    public AdminBuilder WithPosition(EnumPosition position)
    {
        Position = position;
        return this;
    }

    public AdminBuilder WithCompany(Company company)
    {
        Company = company;
        return this;
    }
}