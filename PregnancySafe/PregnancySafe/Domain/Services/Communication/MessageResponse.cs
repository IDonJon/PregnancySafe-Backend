using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class MessageResponse : BaseResponse
    {
        public Message Message { get; private set; }
        public MessageResponse(bool success, string responseMessage, Message message) : base(success, responseMessage)
        {
            Message = message;
        }
        public MessageResponse(Message message) : this(true, string.Empty, message) { }
        public MessageResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}
