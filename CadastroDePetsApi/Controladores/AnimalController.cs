using CadastroDePetsApi.Apresentacao.DTOs;
using CadastroDePetsApi.Persistencia.Context.Interfaces;
using CadastroDePetsApi.Persistencia.Entidades;
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
        return new List<AnimalDto> { new AnimalDto
                {
                    AnimalId = 1,
                    Nome = "Rex",
                    Idade = 5,
                    Genero = 'M',
                    Raca = "Labrador",
                    Proprietario = new ProprietarioDto
                    {
                        ProprietarioId = 1,
                        Nome = "João Silva",
                        Endereco = "Rua das Flores, 123",
                        Telefone = "11999999999"
                    }
                },
                new AnimalDto
                {
                    AnimalId = 2,
                    Nome = "Mia",
                    Idade = 3,
                    Genero = 'F',
                    Raca = "Persa",
                    Proprietario = new ProprietarioDto
                    {
                        ProprietarioId = 2,
                        Nome = "Maria Oliveira",
                        Endereco = "Av. Brasil, 456",
                        Telefone = "11988888888"
                    }
                },
                new AnimalDto
                {
                    AnimalId = 3,
                    Nome = "Bolt",
                    Idade = 2,
                    Genero = 'M',
                    Raca = "Husky",
                    Proprietario = new ProprietarioDto
                    {
                        ProprietarioId = 3,
                        Nome = "Carlos Souza",
                        Endereco = "Rua do Sol, 789",
                        Telefone = "11977777777"
                    }
                }};
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