using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public class AnimeRepository : IAnimeRepository
{
    public Task<Anime> add(Anime anime)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Anime>> animesByIdDirector(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Anime> delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Anime> getAnimeByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Anime>> getAnimesByKeyWords(string summary)
    {
        throw new NotImplementedException();
    }

    public Task<Anime> update(Anime anime)
    {
        throw new NotImplementedException();
    }
}
