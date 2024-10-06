using Application.Features.AnimeFeature;
using Application.Features.AnimeFeatures;
using Domain.Entities;
using Domain.Exceptions;
using Infraestructure.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimesController : ControllerBase
{
    private readonly IMediator _mediator;
    public AnimesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        var anime = await _mediator.Send(new GetAnimesQuery());
        if (!anime.animes.Any())
        {
            return NotFound(new { Message = "Não existe anime" });
        }

        return Ok(anime);

    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateAnimeCommand request)
    {
        var anime = await _mediator.Send(request);
        if (anime.anime is null)
        {
            return BadRequest(new { Message = "Não foi possível criar o anime." });
        }
        return Ok(anime);
    }
    [HttpGet("GetAnimeById")]
    public async Task<IActionResult> GetAnimeById([FromQuery] GetAnimeQuery request)
    {
        var anime = await _mediator.Send(request);

        return anime.anime is null ?
        NotFound(new { Message = "anime não encontrado" }) :
        Ok(anime);
    }
    [HttpGet("GetAnimesByKeywords")]
    public async Task<IActionResult> GetAnimesByKeyWords([FromQuery] GetAnimesByKeyWordsQuery request)
    {
        var anime = await _mediator.Send(request);
        return !anime.Animes.Any() ?
        NotFound(new { Message = "animes com essa palavra-chaves não encontrado" }) :
        Ok(anime);
    }
    [HttpGet("GetAnimesByIdDirector")]
    public async Task<IActionResult> GetAnimesByIdDirector([FromQuery] GetAnimesByIdDirectorQuery request)
    {
        var anime = await _mediator.Send(request);
        return !anime.Animes.Any() ?
        NotFound(new { Message = "Esse diretor não tem animes" }) :
        Ok(anime);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAnimeCommand request)
    {
        var anime = await _mediator.Send(request);
        return anime.anime is null ?
        BadRequest(new { Message = "Não foi possível atualizar o anime" }) :
        Ok(anime);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteAnimeCommand request)
    {
        /*var anime = await _mediator.Send(request);
        return anime.anime is null ?
        NotFound(new { Message = "Anime não encontrado" }) :
        Ok(anime);*/
        try
        {
            var deletedAnime = await _mediator.Send(request);
            return Ok(deletedAnime);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

}
