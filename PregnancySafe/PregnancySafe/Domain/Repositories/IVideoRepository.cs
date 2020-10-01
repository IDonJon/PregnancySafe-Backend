using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Repositories
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> ListAsync();
        Task<Video> FindByIdAsync(int id);
        Task AddAsync(Video video);
        void Update(Video video);
        void Remove(Video video);
    }
}
