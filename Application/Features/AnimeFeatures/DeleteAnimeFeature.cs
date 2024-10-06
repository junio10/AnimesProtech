using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AnimeFeature;
public record DeleteAnimeCommand(
    int id
    ) : IRequest<DeleteAnimeResponse>;

public record DeleteAnimeResponse(Anime anime);

public class DeleteAnimeHandler : IRequestHandler<DeleteAnimeCommand, DeleteAnimeResponse>
{
    private readonly IAnimeRepository _animeRepository;
    public DeleteAnimeHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<DeleteAnimeResponse> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
    {
        var newAnime = await _animeRepository.Delete(request.id);
        return new DeleteAnimeResponse(newAnime);
    }
}
