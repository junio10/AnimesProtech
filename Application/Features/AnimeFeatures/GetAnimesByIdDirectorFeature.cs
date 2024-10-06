using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AnimeFeature;

public record GetAnimesByIdDirectorCommand(
    int idDiretor
    ) : IRequest<GetAnimesByIdDirectorResponse>;

public record GetAnimesByIdDirectorResponse(IEnumerable<Anime> Animes);

public class GetAnimesByIdDirectorHandler : IRequestHandler<GetAnimesByIdDirectorCommand, GetAnimesByIdDirectorResponse>
{
    private readonly IAnimeRepository _animeRepository;
    public GetAnimesByIdDirectorHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<GetAnimesByIdDirectorResponse> Handle(GetAnimesByIdDirectorCommand request, CancellationToken cancellationToken)
    {
        var newAnime = await _animeRepository.AnimesByIdDirector(request.idDiretor);
        return new GetAnimesByIdDirectorResponse(newAnime);
    }
}
