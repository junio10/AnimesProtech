using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IUnitOfWork
    {
        IAnimeRepository AnimeRepository { get; }
        Task CommitAsync();
    }
}
