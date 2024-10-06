using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DirectorFetures;

public record CreateDirectorCommand(
    string name
    ) : IRequest<CreateDirectorResponse>;

public record CreateDirectorResponse(Director Director);

public class CreateDirectorHandler : IRequestHandler<CreateDirectorCommand, CreateDirectorResponse>
{
    private readonly IDirectorRepository _directorRepository;
    public CreateDirectorHandler(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<CreateDirectorResponse> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        Director director = new Director { Name = request.name };
        var newAnime = await _directorRepository.Add(director);
        return new CreateDirectorResponse(newAnime);
    }
}
