using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AnimeFeature;

public record CreateAnimeCommand(
    string name,
    string summary,
    int idDiretor
    ) : IRequest<CreateAnimeResponse>;

public record CreateAnimeResponse(Anime anime);

public class CreateAnimeHandler : IRequestHandler<CreateAnimeCommand, CreateAnimeResponse>
{
    private readonly IAnimeRepository _animeRepository;
    public CreateAnimeHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<CreateAnimeResponse> Handle(CreateAnimeCommand request, CancellationToken cancellationToken)
    {
        Anime anime = new Anime() { Name = request.name, Summary = request.summary, DirectorId = request.idDiretor };
        var newAnime = await _animeRepository.Add(anime);
        return new CreateAnimeResponse(newAnime);
    }
}
