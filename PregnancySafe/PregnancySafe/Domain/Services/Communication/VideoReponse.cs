using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class VideoResponse : BaseResponse
    {
        public Video Video { get; private set; }
        public VideoResponse(bool success, string responseMessage, Video video) : base(success, responseMessage)
        {
            Video = video;
        }

        public VideoResponse(Video video) : this(true, string.Empty, video) { }
        public VideoResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}
