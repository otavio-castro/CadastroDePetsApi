using CadastroDePetsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePetsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProprietarioController : ControllerBase
{
    [HttpPost("CadastrarProprietario")]
    public IActionResult CadastrarProprietario([FromBody] Proprietario proprietario)
    {
        return StatusCode(201);
    }

    [HttpDelete("ExcluirProprietarioPorId/{id}")]
    public IActionResult ExcluirProprietarioPorId(int id)
    {
        return Ok();
    }
}