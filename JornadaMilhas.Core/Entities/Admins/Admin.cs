﻿using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Admins.Enums;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Entities.Flights;

namespace JornadaMilhas.Core.Entities.Admins;

public class Admin : User
{
    public Company Company;

    public decimal Salary { get; }

    public EnumPosition Position { get; }

    public Admin(AdminBuilder builder) : base(
        builder.Name,
        builder.DtBirth,
        builder.Genre,
        builder.Cpf,
        builder.Phone,
        builder.Address,
        builder.Picture,
        builder.Mail,
        builder.ConfirmMail,
        builder.Password)
    {
        Position = builder.Position;
        Company = builder.Company;
    }
}