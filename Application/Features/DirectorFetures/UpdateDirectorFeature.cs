using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DirectorFetures;

public record UpdateDirectorCommand(
    int id,
    string name
    ) : IRequest<UpdateDirectorResponse>;

public record UpdateDirectorResponse(Director Director);

public class UpdateDirectorHandler : IRequestHandler<UpdateDirectorCommand, UpdateDirectorResponse>
{
    private readonly IDirectorRepository _directorRepository;
    public UpdateDirectorHandler(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<UpdateDirectorResponse> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
    {
        Director director = new Director { Id = request.id,Name = request.name };
        var newAnime = await _directorRepository.Update(director);
        return new UpdateDirectorResponse(newAnime);
    }
}

