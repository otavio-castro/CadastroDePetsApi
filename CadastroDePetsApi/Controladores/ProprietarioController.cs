using CadastroDePetsApi.Apresentacao.Servico.Interfaces;
using CadastroDePetsApi.Persistencia.Context.Interfaces;
using CadastroDePetsApi.Persistencia.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePetsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProprietarioController : ControllerBase
{
    private readonly IProprietarioServico _proprietarioServico;
    public static string animalCaminho = "animais.xml";
    public static string proprietarioCaminho = "proprietarios.xml";

    public ProprietarioController(IProprietarioServico proprietarioServico)
    {
        _proprietarioServico = proprietarioServico;
    }

    [HttpPost("CadastrarProprietario")]
    public IActionResult CadastrarDono([FromBody] Proprietario proprietario)
    {
        return _proprietarioServico.CadastrarProprietario(proprietario)
        ? StatusCode(201)
        : Conflict("Já existe uma pessoa cadastrada com esse Id");
    }

    [HttpDelete("ExcluirProprietarioPorId/{id}")]
    public IActionResult ExcluirProprietarioPorId(int id)
    {
        return Ok();
    }
}