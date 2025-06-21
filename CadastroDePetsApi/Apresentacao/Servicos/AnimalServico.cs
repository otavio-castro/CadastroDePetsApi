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

    public ActionResult<AnimalDto> AlterarInformacoesPet(int id, AnimalDto animalDto)
    {
        try
        {
            var animais = _xmlContext.CarregarDados<Animal>(animalCaminho);

            var animalExistente = animais.FirstOrDefault(a => a.AnimalId == id);
            if (animalExistente == null)
                return new NotFoundResult();

            var animalAtualizado = _autoMapper.Map<Animal>(animalDto);
            animalAtualizado.AnimalId = id;

            var listaAtualizada = animais.Where(a => a.AnimalId != id).ToList();
            listaAtualizada.Add(animalAtualizado);

            _xmlContext.LimparDados<Animal>(animalCaminho);
            _xmlContext.SalvarDados(animalCaminho, listaAtualizada);

            var proprietarios = _xmlContext.CarregarDados<Proprietario>(proprietarioCaminho);
            var animalDtoRetorno = _autoMapper.Map<AnimalDto>(animalAtualizado);

            var proprietario = proprietarios.FirstOrDefault(p => p.ProprietarioId == animalAtualizado.ProprietarioId);
            if (proprietario != null)
                animalDtoRetorno.Proprietario = _autoMapper.Map<ProprietarioDto>(proprietario);

            return animalDtoRetorno;
        }
        catch
        {
            return new StatusCodeResult(500);
        }
    }
}