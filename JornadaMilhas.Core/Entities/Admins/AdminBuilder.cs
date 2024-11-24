using JornadaMilhas.Common.Builder;
using JornadaMilhas.Core.Entities.Admins.Enums;

namespace JornadaMilhas.Core.Entities.Admins;

public class AdminBuilder : UserBuilder<Admin, AdminBuilder>
{
    public EnumPosition Position { get; private set; }

    public AdminBuilder WithPosition(EnumPosition position)
    {
        Position = position;
        return this;
    }
}