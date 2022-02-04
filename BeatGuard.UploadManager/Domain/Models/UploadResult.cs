using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatGuard.UploadManager.Domain.Models
{
    public class UploadResult
    {
        public int TrackId { get; set; }

        public UploadResult(int trackId)
        {
            TrackId = trackId;
        }
    }
}
