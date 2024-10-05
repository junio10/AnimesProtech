using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IDirectorRepository
    {
        Task<Director> add(Director director);
        Task<Director> update(int id);
        Task<Director> getDirectorByName(string name);

        Task<IEnumerable<Director>> getAllDirector();

    }
}
