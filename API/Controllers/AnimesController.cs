using Application.Features.AnimeFeature;
using Domain.Entities;
using Infraestructure.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimesController : ControllerBase
{
    private readonly IMediator _mediator;
    public AnimesController(IMediator mediator) {
        _mediator = mediator;
    }
    [HttpGet("getAnimes")]
    public async Task<GetAnimesResponse> Index()
    {
       return await  _mediator.Send(new GetAnimesQuery());
    }
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateAnimeCommand request)
    {
        var anime = await _mediator.Send(request);
        if (anime.anime is null) {
            return BadRequest(new { Message = "Não foi possível criar o anime." });
        }
        return Ok(anime);
    }


}
