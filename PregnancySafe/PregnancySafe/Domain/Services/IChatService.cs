using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services
{
    public interface IChatService
    {
        Task<IEnumerable<Chat>> ListAsync();
        Task<ChatResponse> SaveAsync(Chat chat, int motherId, int obstetricianId);
        Task<ChatResponse> UpdateAsync(int id, Chat chat);
        Task<ChatResponse> DeleteAsync(int id);
    }
}