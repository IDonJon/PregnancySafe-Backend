using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> ListAsync();
        Task<Message> FindByIdAsync(int id);
        Task AddAsync(Message message);
        void Update(Message message);
        void Remove(Message message);
    }
}
