using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DirectorFetures;

public record GetAllDirectorsQuery(
    ) : IRequest<GetAllDirectorsResponse>;

public record GetAllDirectorsResponse(IEnumerable<Director> Director);

public class GetAllDirectorsHandler : IRequestHandler<GetAllDirectorsQuery, GetAllDirectorsResponse>
{
    private readonly IDirectorRepository _directorRepository;
    public GetAllDirectorsHandler(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<GetAllDirectorsResponse> Handle(GetAllDirectorsQuery request, CancellationToken cancellationToken)
    {
       
        var newAnime = await _directorRepository.GetAllDirectors();
        return new GetAllDirectorsResponse(newAnime);
    }
}
