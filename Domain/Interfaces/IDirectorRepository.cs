using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
