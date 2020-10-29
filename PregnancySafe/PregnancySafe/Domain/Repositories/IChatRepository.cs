using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Repositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> ListAsync();
        Task<Chat> FindByIdAsync(int id);
        Task AddAsync(Chat chat);
        void Update(Chat chat);
        void Remove(Chat chat);
    }
}
