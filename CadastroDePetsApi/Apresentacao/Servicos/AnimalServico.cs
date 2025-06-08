using AutoMapper;
using CadastroDePetsApi.Apresentacao.DTOs;
using CadastroDePetsApi.Apresentacao.Servico.Interfaces;
using CadastroDePetsApi.Persistencia.Context.Interfaces;
using CadastroDePetsApi.Persistencia.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePetsApi.Apresentacao.Servico;

public class AnimalServico : IAnimalServico
{
    private readonly IMapper _autoMapper;
    private readonly IAppXmlContext _xmlContext;
    public static string animalCaminho = "animais.xml";
    public static string proprietarioCaminho = "proprietarios.xml";

    public AnimalServico(IMapper autoMapper, IAppXmlContext xmlContext)
    {
        _autoMapper = autoMapper;
        _xmlContext = xmlContext;
    }

    public bool CadastrarAnimal(Animal animal)
    {
        var animaisCadastrados = _xmlContext.CarregarDados<Animal>(animalCaminho);

        if (animaisCadastrados.Any(a => a.AnimalId == animal.AnimalId))
            return false;

        _xmlContext.SalvarDados(animalCaminho, new List<Animal> { animal });

        return true;
    }

    public ActionResult<IEnumerable<AnimalDto>> BuscarAnimais()
    {
        try
        {
            var animais = _xmlContext.CarregarDados<Animal>(animalCaminho);
            var proprietarios = _xmlContext.CarregarDados<Proprietario>(proprietarioCaminho);

            var animaisDto = animais.Select(animal =>
            {
                var animalDto = _autoMapper.Map<AnimalDto>(animal);
                var proprietario = proprietarios.FirstOrDefault(p => p.ProprietarioId == animal.ProprietarioId);

                if (proprietario != null)
                    animalDto.Proprietario = _autoMapper.Map<ProprietarioDto>(proprietario);

                return animalDto;
            }).ToList();

            return animaisDto;
        }
        catch
        {
            return new List<AnimalDto>();
        }
    }
}