

using API_Domains.Interfaces;
using API_Domains.Repository;
using API_Domains.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Configuration.Configuracao
{
    public static class ConfiguracaoApi
    {
        public static void AddApiConfiguracao(this IServiceCollection services)
        {

            services.AddTransient<IDepoimentosService, DepoimentosService>();
            services.AddTransient<IDepoimentosRepository, DepoimentoRepository>();

        }

    }
}
