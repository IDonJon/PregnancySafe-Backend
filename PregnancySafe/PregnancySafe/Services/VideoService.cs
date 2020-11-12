using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Repositories;
using PregnancySafe.Domain.Services;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IObstetricianRepository _obstetricianRepository;
        public VideoService(IVideoRepository videoRepository, IUnitOfWork unitOfWork,
            IObstetricianRepository obstetricianRepository)
        {
            _videoRepository = videoRepository;
            _unitOfWork = unitOfWork;
            _obstetricianRepository = obstetricianRepository;
        }

        public async Task<VideoResponse> DeleteAsync(int id)
        {
            var existingVideo = await _videoRepository.FindByIdAsync(id);

            if (existingVideo == null)
                return new VideoResponse("Video not found");

            try
            {
                _videoRepository.Remove(existingVideo);
                await _unitOfWork.CompleteAsync();
                return new VideoResponse(existingVideo);
            }
            catch (Exception exception)
            {
                return new VideoResponse($"An error ocurred while deleting video: {exception.Message}");
            }
        }

        public async Task<IEnumerable<Video>> ListAsync()
        {
            return await _videoRepository.ListAsync();
        }

        public async Task<VideoResponse> SaveAsync(Video video, int obstetricianId)
        {
            var existingObstetrician = await _obstetricianRepository
               .FindByIdAsync(obstetricianId);
            if (existingObstetrician == null)
                return new VideoResponse("Obstetrician not found");

            video.Obstetrician = existingObstetrician;

            try
            {
                await _videoRepository.AddAsync(video);
                await _unitOfWork.CompleteAsync();
                return new VideoResponse(video);
            }
            catch (Exception exception)
            {
                return new VideoResponse($"An error ocurred while saving the video: {exception.Message}");
            }
        }

        public async Task<VideoResponse> UpdateAsync(int id, Video video)
        {
            var existingVideo = await _videoRepository.FindByIdAsync(id);

            if (existingVideo == null)
                return new VideoResponse("Video not found");

            try
            {
                _videoRepository.Update(existingVideo);
                await _unitOfWork.CompleteAsync();
                return new VideoResponse(existingVideo);
            }
            catch (Exception exception)
            {
                return new VideoResponse($"An error ocurred while updating the Video: {exception.Message}");
            }
        }
    }
}
