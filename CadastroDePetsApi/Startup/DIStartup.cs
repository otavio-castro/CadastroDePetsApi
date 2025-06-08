using CadastroDePetsApi.Persistencia.Context;
using CadastroDePetsApi.Persistencia.Context.Interfaces;

namespace CadastroDePetsApi.Startup;

public class DIStartup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IAppXmlContext, AppXmlContext>();
    }
}