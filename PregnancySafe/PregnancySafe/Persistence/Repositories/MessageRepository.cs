using Microsoft.EntityFrameworkCore;
using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Repositories;
using PregnancySafe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Persistence.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _context.Messages.Include(p => p.Chat).ToListAsync();
        }
        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }
        public async Task<Message> FindByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }
        public void Remove(Message message)
        {
            _context.Messages.Remove(message);
        }
        public void Update(Message message)
        {
            _context.Messages.Update(message);
        }
    }
}
