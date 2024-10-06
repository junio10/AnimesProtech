using MediatR;
using Application.Interfaces.Repositories;
using Domain.Entities;
namespace Application.Features.AnimeFeature;

public record GetAnimeQuery(int id) : IRequest<GetAnimeResponse>;

public record GetAnimeResponse(Anime anime);

public class GetAnimeHandler : IRequestHandler<GetAnimeQuery, GetAnimeResponse>
{
    private readonly IAnimeRepository _animeRepository;
    public GetAnimeHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<GetAnimeResponse> Handle(GetAnimeQuery request, CancellationToken cancellationToken)
    {

        var anime = await _animeRepository.GetAnimeById(request.id);
        if (anime is null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        return new GetAnimeResponse(anime);
    }
}

