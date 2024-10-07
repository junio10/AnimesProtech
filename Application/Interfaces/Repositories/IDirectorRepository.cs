using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IDirectorRepository
    {
        Task<Director> Add(Director director);
        Task<Director> Update(Director director);
        Task<Director> GetDirectorByName(string name);

        Task<Director> GetDirectorById(int id);

        Task<IEnumerable<Director>> GetAllDirectors();

        Task CommitAsync();

    }
}
