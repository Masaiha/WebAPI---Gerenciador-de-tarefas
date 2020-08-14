using MasaIO.business.Interface.Repository;
using MasaIO.business.Interface.Services;
using MasaIO.business.Interface.Validation;
using MasaIO.business.Service;
using MasaIO.business.Service.Validation;
using MasaIO.Data.Context;
using MasaIO.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasaIO.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependenciesInjections(this IServiceCollection services)
        {
            services.AddScoped<GerenciadorTarefasContext>();

            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<IEquipeService, EquipeService>();
            services.AddScoped<ITarefaService, TarefaService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }

    }
}
