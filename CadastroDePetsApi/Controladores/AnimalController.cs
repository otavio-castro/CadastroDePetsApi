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

        if (!animais.Value.Any())
            return NotFound(new { Status = "Arquivo xml vazio" });

        return animais;
    }

    [HttpGet("BuscarPetPorId/{id}")]
    public IEnumerable<AnimalDto> BuscarPetPorId(int id)
    {
        return new List<AnimalDto> { new AnimalDto() };
    }

    [HttpGet("OrdenarPetsOrdemAlfabetica")]
    public ActionResult<IEnumerable<AnimalDto>> OrdenarPetsOrdemAlfabetica()
    {
        var animais = _animalServico.OrdenarAlfabetico();

        if (!animais.Value.Any())
            return NotFound(new { Status = "Arquivo xml vazio ou sem animais cadastrados" });

        return animais;
    }

    [HttpPut("AlterarInformacoesPet/{id}")]
    public IActionResult AlterarInformacoesPet(int id)
    {
        return Ok();
    }

    [HttpDelete("ExcluirPetPorId/{id}")]
    public IActionResult ExcluirPetPorId(int id)
    {
        return Ok();
    }
}
