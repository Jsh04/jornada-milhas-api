using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Persistence.Queue;

public sealed class QueueGeneric
{
    public Guid Id { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Content { get; set; }

    public DateTime TimeCreated { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public string? Error { get; set; }

}
