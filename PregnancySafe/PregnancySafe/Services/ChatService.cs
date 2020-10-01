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
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        public async Task<IEnumerable<Chat>> ListAsync()
        {
            return await _chatRepository.ListAsync();
        }
        public async Task<ChatResponse> SaveAsync(Chat chat)
        {
            try
            {
                await _chatRepository.AddAsync(chat);
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
                return new ChatResponse(existingChat);
            }
            catch (Exception exception)
            {
                return new ChatResponse($"An error ocurred while updating the Chat: {exception.Message}");
            }
        }
    }
}