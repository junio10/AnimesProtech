using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IAnimeRepository
    {
        Task<Anime> Add(Anime anime);
        Task<Anime> Update(Anime anime);
        Task<Anime> Delete(int id);
        Task<Anime> GetAnimeByName(string name);
        Task<IEnumerable<Anime>> GetAnimesByKeyWords(string summary);
        Task<IEnumerable<Anime>> AnimesByIdDirector(int id);
        Task<IEnumerable<Anime>> GetAllAnimes();
        Task<Anime?> GetAnimeById(int id);
        Task CommitAsync();





    }
}
