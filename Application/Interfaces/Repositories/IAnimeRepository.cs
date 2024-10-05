using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IAnimeRepository
    {
        Task<Anime> add(Anime anime);
        Task<Anime> update(Anime anime);
        Task<Anime> delete(int id);
        Task<Anime> getAnimeByName(string name);
        Task<IEnumerable<Anime>> getAnimesByKeyWords(string summary);
        Task<IEnumerable<Anime>> animesByIdDirector(int id);





    }
}
