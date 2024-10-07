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
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        var directors = await _mediator.Send(new GetAllDirectorsQuery());
        return directors.Director is null ? NotFound(new { Message = "Não existe diretores." }) : Ok(directors);
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateDirectorCommand request)
    {
        var director = await _mediator.Send(request);
        if(director.Director is null)
        {
            return BadRequest(new { Message = "Erro, Diretor não criado." });
        }
        return Ok(director);
    }

    [HttpGet("GetByName")]
    public async Task<IActionResult> GetDirectorByName([FromQuery] GetDirectorByNameQuery request)
    {
        
        var director = await _mediator.Send(request);

       
        if (director.Director is null)
        {
            
            return NotFound(new { Message = "Diretor não encontrado." });
        }

       
        return Ok(director);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetDirectorById([FromQuery] GetDirectorByIdQuery request)
    {

        var director = await _mediator.Send(request);


        if (director.Director is null)
        {

            return NotFound(new { Message = "Diretor não encontrado." });
        }


        return Ok(director);
    }
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateDirectorCommand request)
    {
        var director = await _mediator.Send(request);

        if (director.Director is null)
        {
            return BadRequest(new { Message = "Não foi possível atualizar o diretor" });
        }

        return Ok(director);
    }
}

