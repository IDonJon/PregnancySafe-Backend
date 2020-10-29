using Microsoft.EntityFrameworkCore;
using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Repositories;
using PregnancySafe.Domain.Services.Communication;
using PregnancySafe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Persistence.Repositories
{
    public class ChatRepository : BaseRepository, IChatRepository
    {
        public ChatRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Chat>> ListAsync()
        {
            return await _context.Chats.ToListAsync();
        }
        public async Task AddAsync(Chat chat)
        {
            await _context.Chats.AddAsync(chat);
        }
        public async Task<Chat> FindByIdAsync(int id)
        {
            return await _context.Chats.FindAsync(id);
        }
        public void Update(Chat chat)
        {
            _context.Chats.Update(chat);
        }
        public void Remove(Chat chat)
        {
            _context.Chats.Remove(chat);
        }

    }
}
