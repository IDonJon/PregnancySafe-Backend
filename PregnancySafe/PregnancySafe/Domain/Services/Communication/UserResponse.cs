using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; private set; }
        public UserResponse(bool success, string responseMessage, User user) : base(success, responseMessage)
        {
            User = user;
        }

        public UserResponse(User user) : this(true, string.Empty, user) { }
        public UserResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}
