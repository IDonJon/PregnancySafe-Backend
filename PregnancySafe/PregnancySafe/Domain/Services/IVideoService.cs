using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services
{
    public interface IVideoService
    {
        Task<IEnumerable<Video>> ListAsync();
        Task<VideoResponse> SaveAsync(Video video, int obstetricianId);
        Task<VideoResponse> UpdateAsync(int id, Video video);
        Task<VideoResponse> DeleteAsync(int id);
    }

}
