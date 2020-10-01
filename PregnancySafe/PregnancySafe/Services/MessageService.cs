using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Repositories;
using PregnancySafe.Domain.Services;
using PregnancySafe.Domain.Services.Communication;
using PregnancySafe.Persistence.Context;
using PregnancySafe.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PregnancySafe.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _messageRepository.ListAsync();
        }
        public async Task<MessageResponse> SaveAsync(Message message)
        {
            try
            {
                await _messageRepository.AddAsync(message);
                return new MessageResponse(message);
            }
            catch (Exception exception)
            {
                return new MessageResponse($"An error ocurred while saving the Message: {exception.Message}");
            }
        }
        public async Task<MessageResponse> DeleteAsync(int id)
        {
            var existingMessage = await _messageRepository.FindByIdAsync(id);

            if (existingMessage == null)
                return new MessageResponse("Message not found");
            try
            {
                _messageRepository.Remove(existingMessage);
                return new MessageResponse(existingMessage);
            }
            catch (Exception exception)
            {
                return new MessageResponse($"An error ocurred while deleting the Message: {exception.Message}");
            }
        }
        public async Task<MessageResponse> UpdateAsync(int id, Message message)
        {
            var existingMessage = await _messageRepository.FindByIdAsync(id);
            if (existingMessage == null)
                return new MessageResponse("Message not found");
            existingMessage.Text = message.Text;
            try
            {
                _messageRepository.Update(existingMessage);
                return new MessageResponse(existingMessage);
            }
            catch (Exception exception)
            {
                return new MessageResponse($"An error ocurred while updating the Message: {exception.Message}");
            }
        }
    }
}
