using CadastroDePetsApi.Context.Interfaces;
using CadastroDePetsApi.DTOs;
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

    [HttpGet("BuscarPets")]
    public IEnumerable<AnimalDto> BuscarPets()
    {
        return new List<AnimalDto> {  new AnimalDto
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
            Telefone = "(31) 99999-1111"
        }
    },
    new AnimalDto
    {
        AnimalId = 2,
        Nome = "Luna",
        Idade = 3,
        Genero = 'F',
        Raca = "Poodle",
        Proprietario = new ProprietarioDto
        {
            ProprietarioId = 2,
            Nome = "Maria Oliveira",
            Endereco = "Av. Brasil, 456",
            Telefone = "(31) 98888-2222"
        }
    },
    new AnimalDto
    {
        AnimalId = 3,
        Nome = "Thor",
        Idade = 2,
        Genero = 'M',
        Raca = "Husky Siberiano",
        Proprietario = new ProprietarioDto
        {
            ProprietarioId = 3,
            Nome = "Carlos Souza",
            Endereco = "Rua Tiradentes, 789",
            Telefone = "(31) 97777-3333"
        }
    },
    new AnimalDto
    {
        AnimalId = 4,
        Nome = "Mel",
        Idade = 4,
        Genero = 'F',
        Raca = "Golden Retriever",
        Proprietario = new ProprietarioDto
        {
            ProprietarioId = 4,
            Nome = "Fernanda Lima",
            Endereco = "Alameda dos Anjos, 101",
            Telefone = "(31) 96666-4444"
        }
    }};
    }

    [HttpGet("BuscarPetPorId/{id}")]
    public IEnumerable<AnimalDto> BuscarPetPorId(int id)
    {
        return new List<AnimalDto> { new AnimalDto() };
    }
}