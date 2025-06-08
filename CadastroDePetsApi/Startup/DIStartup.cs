using CadastroDePetsApi.Apresentacao.Mappers;
using CadastroDePetsApi.Apresentacao.Servico;
using CadastroDePetsApi.Apresentacao.Servico.Interfaces;
using CadastroDePetsApi.Persistencia.Context;
using CadastroDePetsApi.Persistencia.Context.Interfaces;

namespace CadastroDePetsApi.Startup;

public class DIStartup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IAppXmlContext, AppXmlContext>();
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddScoped<IAnimalServico, AnimalServico>();
        services.AddScoped<IProprietarioServico, ProprietarioServico>();
    }
}