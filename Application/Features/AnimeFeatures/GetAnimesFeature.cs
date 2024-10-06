using MediatR;
using Application.Interfaces.Repositories;
using Domain.Entities;
namespace Application.Features.AnimeFeature;

public record GetAnimesQuery() : IRequest<GetAnimesResponse>;

public record GetAnimesResponse(IEnumerable<Anime> animes);

public class GetAnimesHandler : IRequestHandler<GetAnimesQuery, GetAnimesResponse>
{
    private readonly IAnimeRepository _animeRepository;
    public GetAnimesHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<GetAnimesResponse> Handle(GetAnimesQuery request, CancellationToken cancellationToken)
    {

        var animes = await _animeRepository.GetAllAnimes();

        return new GetAnimesResponse(animes);
    }
}

