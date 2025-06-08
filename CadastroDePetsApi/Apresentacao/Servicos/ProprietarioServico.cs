using AutoMapper;
using CadastroDePetsApi.Apresentacao.Servico.Interfaces;
using CadastroDePetsApi.Persistencia.Context.Interfaces;
using CadastroDePetsApi.Persistencia.Entidades;

namespace CadastroDePetsApi.Apresentacao.Servico;

public class ProprietarioServico : IProprietarioServico
{
    private readonly IMapper _autoMapper;
    private readonly IAppXmlContext _xmlContext;
    public static string animalCaminho = "animais.xml";
    public static string proprietarioCaminho = "proprietarios.xml";

    public ProprietarioServico(IMapper autoMapper, IAppXmlContext xmlContext)
    {
        _autoMapper = autoMapper;
        _xmlContext = xmlContext;
    }

     public bool CadastrarProprietario(Proprietario proprietario)
    {
        var proprietariosCadastrados = _xmlContext.CarregarDados<Proprietario>(proprietarioCaminho);

        if (proprietariosCadastrados.Any(a => a.ProprietarioId == proprietario.ProprietarioId))
            return false;

        _xmlContext.SalvarDados(proprietarioCaminho, new List<Proprietario> { proprietario });

        return true;
    }
}
