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
    public class VideoRepository : BaseRepository, IVideoRepository
    {
        public VideoRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Video video)
        {
            await _context.Videos.AddAsync(video);
        }

        public async Task<Video> FindByIdAsync(int id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task<IEnumerable<Video>> ListAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public void Remove(Video video)
        {
            _context.Videos.Remove(video);
        }

        public void Update(Video video)
        {
            _context.Videos.Update(video);
        }
    }
}
