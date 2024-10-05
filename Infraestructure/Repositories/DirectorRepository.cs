using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public class DirectorRepository : IDirectorRepository
{
    public Task<Director> add(Director director)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Director>> getAllDirector()
    {
        throw new NotImplementedException();
    }

    public Task<Director> getDirectorByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Director> update(int id)
    {
        throw new NotImplementedException();
    }
}
