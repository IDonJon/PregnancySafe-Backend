using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services;
using PregnancySafe.Extensions;
using PregnancySafe.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Controllers
{
    [Route("/api/[controller]")]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;
        public ChatController(IChatService chatService, IMapper mapper)
        {
            _chatService = chatService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ChatResource>> GetAllAsync()
        {
            var chats = await _chatService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Chat>, IEnumerable<ChatResource>>(chats);
            return resources;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveChatResource resource)
        {
            var chat = _mapper.Map<SaveChatResource, Chat>(resource);
            var result = await _chatService.UpdateAsync(id, chat);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var chatResource = _mapper.Map<Chat, ChatResource>(result.Chat);
            return Ok(chatResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveChatResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var chat = _mapper.Map<SaveChatResource, Chat>(resource);
            var result = await _chatService.SaveAsync(chat);

            if (!result.Success)
                return BadRequest(result.Chat);

            var chatResource = _mapper.Map<Chat, ChatResource>(result.Chat);
            return Ok(chatResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _chatService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Chat);
            }

            var chatResource = _mapper.Map<Chat, ChatResource>(result.Chat);
            return Ok(chatResource);
        }
    }
}