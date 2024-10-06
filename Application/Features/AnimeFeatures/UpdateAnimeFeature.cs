using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AnimeFeature;

public record UpdateAnimeCommand(
    string name,
    string summary,
    int idDiretor
    ) : IRequest<UpdateAnimeResponse>;

public record UpdateAnimeResponse(Anime anime);

public class UpdateAnimeHandler : IRequestHandler<UpdateAnimeCommand, UpdateAnimeResponse>
{
    private readonly IAnimeRepository _animeRepository;
    public UpdateAnimeHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<UpdateAnimeResponse> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
    {
        Anime anime = new Anime() { Name = request.name, Summary = request.summary, DirectorId = request.idDiretor };
        var newAnime = await _animeRepository.Update(anime);
        return new UpdateAnimeResponse(newAnime);
    }
}

