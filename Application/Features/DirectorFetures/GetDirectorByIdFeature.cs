using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DirectorFetures;

public record GetDirectorByIdCommand(
    int id
    ) : IRequest<GetDirectorByIdResponse>;

public record GetDirectorByIdResponse(Director Director);

public class GetDirectorByIdHandler : IRequestHandler<GetDirectorByIdCommand, GetDirectorByIdResponse>
{
    private readonly IDirectorRepository _directorRepository;
    public GetDirectorByIdHandler(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<GetDirectorByIdResponse> Handle(GetDirectorByIdCommand request, CancellationToken cancellationToken)
    {

        var newAnime = await _directorRepository.GetDirectorById(request.id);
        return new GetDirectorByIdResponse(newAnime);
    }
}
