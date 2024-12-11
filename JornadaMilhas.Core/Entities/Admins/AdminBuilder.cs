﻿using JornadaMilhas.Common.Builder;
using JornadaMilhas.Core.Entities.Admins.Enums;
using JornadaMilhas.Core.Entities.Companies;

namespace JornadaMilhas.Core.Entities.Admins;

public class AdminBuilder : UserBuilder<Admin, AdminBuilder>
{
    public EnumPosition Position { get; private set; }

    public Company Company { get; private set; }

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