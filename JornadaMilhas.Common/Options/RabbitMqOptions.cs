using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Options;

public sealed class RabbitMqOptions
{
    public string HostName { get; set; }

    public int Port { get; set; }
}
