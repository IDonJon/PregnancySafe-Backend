using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Repositories;
using PregnancySafe.Domain.Services;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PregnancySafe.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMotherRepository _motherRepository;
        private readonly IObstetricianRepository _obstetricianRepository;
        public ChatService(IChatRepository chatRepository, IUnitOfWork unitOfWork,
            IMotherRepository motherRepository, IObstetricianRepository obstetricianRepository)
        {
            _chatRepository = chatRepository;
            _unitOfWork = unitOfWork;
            _motherRepository = motherRepository;
            _obstetricianRepository = obstetricianRepository;
        }
        public async Task<IEnumerable<Chat>> ListAsync()
        {
            return await _chatRepository.ListAsync();
        }
        public async Task<ChatResponse> SaveAsync(Chat chat, int motherId,
            int obstetricianId)
        {

            var existingObstetrician = await _obstetricianRepository
               .FindByIdAsync(obstetricianId);
            if (existingObstetrician == null)
                return new ChatResponse("Obstetrician not found");

            chat.Obstetrician = existingObstetrician;

            var existingMother = await _motherRepository
                .FindByIdAsync(motherId);
            if (existingMother == null)
                return new ChatResponse("Mother not found");

            chat.Mother = existingMother;


            try
            {
                await _chatRepository.AddAsync(chat);
                await _unitOfWork.CompleteAsync();
                return new ChatResponse(chat);
            }
            catch (Exception exception)
            {
                return new ChatResponse($"An error ocurred while saving the Chat: {exception.Message}");
            }
        }
        public async Task<ChatResponse> DeleteAsync(int id)
        {
            var existingChat = await _chatRepository.FindByIdAsync(id);

            if (existingChat == null)
                return new ChatResponse("Chat not found");
            try
            {
                _chatRepository.Remove(existingChat);
                await _unitOfWork.CompleteAsync();
                return new ChatResponse(existingChat);
            }
            catch (Exception exception)
            {
                return new ChatResponse($"An error ocurred while deleting the Chat: {exception.Message}");
            }
        }

        public async Task<ChatResponse> UpdateAsync(int id, Chat chat)
        {
            var existingChat = await _chatRepository.FindByIdAsync(id);

            if (existingChat == null)
                return new ChatResponse("Chat not found");

            try
            {
                _chatRepository.Update(existingChat);
                await _unitOfWork.CompleteAsync();
                return new ChatResponse(existingChat);
            }
            catch (Exception exception)
            {
                return new ChatResponse($"An error ocurred while updating the Chat: {exception.Message}");
            }
        }
        public async Task<ChatResponse> GetByIdAsync(int id)
        {
            var existingChat = await _chatRepository.FindByIdAsync(id);

            if (existingChat == null)
                return new ChatResponse("Chat not found");
            return new ChatResponse(existingChat);
        }
    }
}