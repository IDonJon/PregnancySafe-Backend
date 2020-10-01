using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class ChatResponse : BaseResponse
    {
        public Chat Chat { get; private set; }
        public ChatResponse(bool success, string responseMessage, Chat chat) : base(success, responseMessage)
        {
            Chat = chat;
        }

        public ChatResponse(Chat chat) : this(true, string.Empty, chat) { }
        public ChatResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}
