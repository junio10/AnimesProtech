﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DirectorFetures;

public record GetDirectorByNameQuery(
    string name
    ) : IRequest<GetDirectorByNameResponse>;

public record GetDirectorByNameResponse(Director Director);

public class GetDirectorByNameHandler : IRequestHandler<GetDirectorByNameQuery, GetDirectorByNameResponse>
{
    private readonly IDirectorRepository _directorRepository;
    public GetDirectorByNameHandler(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<GetDirectorByNameResponse> Handle(GetDirectorByNameQuery request, CancellationToken cancellationToken)
    {

        var director = await _directorRepository.GetDirectorByName(request.name);
        return new GetDirectorByNameResponse(director);
    }
}

