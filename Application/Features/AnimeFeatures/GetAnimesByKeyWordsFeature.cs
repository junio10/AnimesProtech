using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AnimeFeature;

public record GetAnimesByKeyWordsQuery(string summary) : IRequest<GetAnimesByKeyWordsResponse>;

public record GetAnimesByKeyWordsResponse(IEnumerable<Anime> Animes);

public class GetAnimesByKeyWordsHandler : IRequestHandler<GetAnimesByKeyWordsQuery, GetAnimesByKeyWordsResponse>
{
    private readonly IAnimeRepository _animeRepository;
    public GetAnimesByKeyWordsHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<GetAnimesByKeyWordsResponse> Handle(GetAnimesByKeyWordsQuery request, CancellationToken cancellationToken)
    {

        var anime = await _animeRepository.GetAnimesByKeyWords(request.summary);
        if (anime is null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        return new GetAnimesByKeyWordsResponse(anime);
    }
}

