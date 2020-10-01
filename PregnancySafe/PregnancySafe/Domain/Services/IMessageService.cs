using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> ListAsync();
        Task<MessageResponse> SaveAsync(Message message);
        Task<MessageResponse> UpdateAsync(int id, Message message);
        Task<MessageResponse> DeleteAsync(int id);
    }
}
