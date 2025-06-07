using CadastroDePetsApi.Context.Interfaces;
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
}