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
    [Route("/api/messages")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MessageResource>> GetAllAsync()
        {
            var messages = await _messageService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMessageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var message = _mapper.Map<SaveMessageResource, Message>(resource);
            var result = await _messageService.SaveAsync(message);

            if (!result.Success)
                return BadRequest(result.Message);

            var messageResource = _mapper.Map<Message, MessageResource>(result.Message);
            return Ok(messageResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveMessageResource resource)
        {
            var message = _mapper.Map<SaveMessageResource, Message>(resource);
            var result = await _messageService.UpdateAsync(id, message);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var messageResource = _mapper.Map<Message, MessageResource>(result.Message);
            return Ok(messageResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _messageService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var messageResource = _mapper.Map<Message, MessageResource>(result.Message);
            return Ok(messageResource);
        }
    }
}
