using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDirectorRepository
    {
        Task<Director> add(Director director);
        Task<Director> update(int id);
        Task<Director> getDirectorByName(String name);

        Task<IEnumerable<Director>> getAllDirector();

    }
}
