using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAnimeRepository
    {
        Task<Anime> add(Anime anime);
        Task<Anime> update(Anime anime);
        Task<Anime> delete(int id);
        Task<Anime> getAnimeByName(String name);
        Task<IEnumerable<Anime>> getAnimesByKeyWords(String summary);
        Task<IEnumerable<Anime>> animesByIdDirector(int id);





    }
}
