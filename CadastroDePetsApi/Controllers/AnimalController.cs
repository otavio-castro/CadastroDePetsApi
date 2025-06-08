using CadastroDePetsApi.Context.Interfaces;
using CadastroDePetsApi.DTOs;
using CadastroDePetsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePetsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAppXmlContext _xmlContext;

    public AnimalController(IAppXmlContext xmlContext)
    {
        _xmlContext = xmlContext;
    }

    [HttpPost("CadastrarPet")]
    public IActionResult CadastrarPet([FromBody] Animal animal)
    {
        return StatusCode(201);
    }

    [HttpGet("RetornarTodosOsPets")]
    public IEnumerable<AnimalDto> RetornarTodosOsPets()
    {
        return new List<AnimalDto> { new AnimalDto() };
    }

    [HttpGet("BuscarPetPorId/{id}")]
    public IEnumerable<AnimalDto> BuscarPetPorId(int id)
    {
        return new List<AnimalDto> { new AnimalDto() };
    }

    [HttpGet("OrdenarPetsOrdemAlfabetica")]
    public IEnumerable<AnimalDto> OrdenarPetsOrdemAlfabetica()
    {
        return new List<AnimalDto> { new AnimalDto() };
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