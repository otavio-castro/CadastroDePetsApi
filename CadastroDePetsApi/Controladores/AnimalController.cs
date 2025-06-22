using CadastroDePetsApi.Apresentacao.DTOs;
using CadastroDePetsApi.Apresentacao.Servico.Interfaces;
using CadastroDePetsApi.Persistencia.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePetsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalServico _animalServico;
    public static string animalCaminho = "animais.xml";
    public static string proprietarioCaminho = "proprietarios.xml";

    public AnimalController(IAnimalServico animalServico)
    {
        _animalServico = animalServico;
    }

    [HttpPost("CadastrarPet")]
    public IActionResult CadastrarPet([FromBody] Animal animal)
    {
        return _animalServico.CadastrarAnimal(animal)
        ? StatusCode(201)
        : Conflict("Já existe um pet cadastrado com esse Id");
    }

    [HttpGet("RetornarTodosOsPets")]
    public ActionResult<IEnumerable<AnimalDto>> RetornarTodosOsPets()
    {
        var animais = _animalServico.BuscarAnimais();

        if (animais?.Value == null || !animais.Value.Any())
            return NotFound(new { Status = "Arquivo xml vazio" });

        return animais;
    }

    [HttpGet("BuscarPetPorId/{id}")]
    public ActionResult<AnimalDto> BuscarPetPorId(int id)
    {
        var animalDto = _animalServico.BuscarAnimalPorId(id);

        if (animalDto == null)
            return NotFound(new { Mensagem = "Pet não encontrado" });

        return animalDto;
    }

    [HttpGet("OrdenarPetsOrdemAlfabetica")]
    public ActionResult<IEnumerable<AnimalDto>> OrdenarPetsOrdemAlfabetica()
    {
        var animais = _animalServico.OrdenarAlfabetico();

        if (animais?.Value == null || !animais.Value.Any())
            return NotFound(new { Status = "Arquivo xml vazio ou sem animais cadastrados" });

        return animais;
    }

    [HttpPut("AlterarInformacoesPet/{id}")]
    public ActionResult<AnimalDto> AlterarInformacoesPet(int id,
    [FromQuery(Name = "novo_nome")] string? nome,
    [FromQuery(Name = "nova_idade")] int idade,
    [FromQuery(Name = "novo_genero")] string? genero,
    [FromQuery(Name = "nova_raca")] string? raca,
    [FromQuery(Name = "novo_id_proprietario")] int proprietarioId)
    {
        Animal animalAtualizado = new Animal
        { AnimalId = id, Nome = nome, Genero = genero, Idade = idade, Raca = raca, ProprietarioId = proprietarioId };

        animalAtualizado.AnimalId = id;

        return _animalServico.AlterarInformacoesPet(animalAtualizado)
        ? StatusCode(201)
        : Conflict("Pet não existente");
    }

    [HttpDelete("ExcluirPetPorId/{id}")]
    public IActionResult ExcluirPetPorId(int id)
    {
        return _animalServico.DeletarPetPorId(id)
       ? StatusCode(201)
       : Conflict("Pet não existente");
    }
}