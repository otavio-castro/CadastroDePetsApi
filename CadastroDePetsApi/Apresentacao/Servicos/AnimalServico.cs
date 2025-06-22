using AutoMapper;
using CadastroDePetsApi.Apresentacao.DTOs;
using CadastroDePetsApi.Apresentacao.Servico.Interfaces;
using CadastroDePetsApi.Persistencia.Context.Interfaces;
using CadastroDePetsApi.Persistencia.Entidades;
using Microsoft.AspNetCore.Http.HttpResults;
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

    // NOVO MÉTODO: BuscarAnimalPorId
    public ActionResult<AnimalDto> BuscarAnimalPorId(int id)
    {
        try
        {
            // Reaproveita o método BuscarAnimais
            var todosAnimais = BuscarAnimais().Value;

            if (todosAnimais == null)
                return new StatusCodeResult(500);

            var animal = todosAnimais.FirstOrDefault(a => a.AnimalId == id);

            if (animal == null)
                return new NotFoundResult();

            return animal;
        }
        catch
        {
            return new StatusCodeResult(500);
        }
    }


    public ActionResult<IEnumerable<AnimalDto>> OrdenarAlfabetico()
    {
        try
        {
            var animais = BuscarAnimais();

            if (animais == null || !animais.Value.Any())
                return new List<AnimalDto>();

            var animaisOrdenados = animais.Value
                .OrderBy(a => a.Nome)
                .ToList();

            return animaisOrdenados;
        }
        catch
        {
            return new List<AnimalDto>();
        }
    }

    public bool DeletarPetPorId(int id)
    {

        var animais = _xmlContext.CarregarDados<Animal>(animalCaminho);

        try
        {

            var listaComAnimalRemovido = from animal in animais
                                         where animal.AnimalId != id
                                         select animal;

            _xmlContext.LimparDados<Animal>(animalCaminho);
            _xmlContext.SalvarDados(animalCaminho, listaComAnimalRemovido.ToList());

            return true;

        }
        catch
        {
            return false;
        }


    }
    public bool AlterarInformacoesPet(Animal animalAtualizado)
    {
        try
        {
            var animais = _xmlContext.CarregarDados<Animal>(animalCaminho);
            var animalAntigo = animais.FirstOrDefault(a => a.AnimalId == animalAtualizado.AnimalId);

            if (animalAntigo == null)
                return false;

            RealizarMapeamentoCondicional(animalAntigo, animalAtualizado);
            DeletarPetPorId(animalAntigo.AnimalId);
            CadastrarAnimal(animalAntigo);

            return true;
        }
        catch
        {
            return false;
        }
    }

    private void RealizarMapeamentoCondicional(Animal animalAntigo, Animal animalNovo)
    {
        if (!string.IsNullOrWhiteSpace(animalNovo.Nome))
            animalAntigo.Nome = animalNovo.Nome;

        if (animalNovo.Idade > 0)
            animalAntigo.Idade = animalNovo.Idade;

        if (!string.IsNullOrWhiteSpace(animalNovo.Genero))
            animalAntigo.Genero = animalNovo.Genero;

        if (!string.IsNullOrWhiteSpace(animalNovo.Raca))
            animalAntigo.Raca = animalNovo.Raca;

        if (animalNovo.ProprietarioId > 0)
            animalAntigo.ProprietarioId = animalNovo.ProprietarioId;
    }
}