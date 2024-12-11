﻿using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Core.Entities;

public class Picture : BaseEntity
{
    private Picture(string pathS3)
    {
        PathS3 = pathS3;
    }

    public string PathS3 { get; init; }

    public long DestinyId { get; init; }

    public Locale Destiny { get; }

    public static Picture Create(string pathS3)
    {
        return new Picture(pathS3);
    }
}