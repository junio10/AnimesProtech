using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DirectorFetures;

public record DeleteDirectorCommand(
    string name
    ) : IRequest<DeleteDirectorResponse>;

public record DeleteDirectorResponse(Director Director);

public class DeleteDirectorHandler : IRequestHandler<DeleteDirectorCommand, DeleteDirectorResponse>
{
    private readonly IDirectorRepository _directorRepository;
    public DeleteDirectorHandler(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<DeleteDirectorResponse> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
    {
        Director director = new Director { Name = request.name };
        var newAnime = await _directorRepository.Add(director);
        return new DeleteDirectorResponse(newAnime);
    }
}
