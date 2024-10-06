using Microsoft.AspNetCore.Mvc;
using Application.Features.AnimeFeature;
using Domain.Entities;
using Infraestructure.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.DirectorFetures;
using Microsoft.AspNetCore.Http.HttpResults;




namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DirectorController : Controller
{
    private readonly IMediator _mediator;
    public DirectorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("index")]
    public async Task<IActionResult> Index()
    {
        var directors = await _mediator.Send(new GetAllDirectorsCommand());
        return directors.Director is null ? NotFound(new { Message = "Não existe diretores." }) : Ok(directors);
    }
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateDirectorCommand request)
    {
        var director = await _mediator.Send(request);
        if(director.Director is null)
        {
            return BadRequest(new { Message = "Erro, Diretor não criado." });
        }
        return Ok(director);
    }

    [HttpGet("getByName")]
    public async Task<IActionResult> GetDirectorByName([FromQuery] GetDirectorByNameCommand request)
    {
        
        var director = await _mediator.Send(request);

       
        if (director.Director is null)
        {
            
            return NotFound(new { Message = "Diretor não encontrado." });
        }

       
        return Ok(director);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetDirectorById([FromQuery] GetDirectorByIdCommand request)
    {

        var director = await _mediator.Send(request);


        if (director.Director is null)
        {

            return NotFound(new { Message = "Diretor não encontrado." });
        }


        return Ok(director);
    }
}

