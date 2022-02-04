using System;
using System.IO;
using System.Threading.Tasks;
using BeatGuard.Uploader.Domain.Entities;
using BeatGuard.Uploader.Domain.Models;
using BeatGuard.Uploader.Infrastructure.Data;
using BeatGuard.Uploader.Infrastructure.Services;

namespace BeatGuard.Uploader.Domain.Services
{
    public class TrackService
    {
        private readonly TrackRepository _trackRepository;
        private readonly TrackStore _trackStore;

        public TrackService(TrackRepository trackRepository, TrackStore trackStore)
        {
            _trackRepository = trackRepository;
            _trackStore = trackStore;
        }

        public async Task<UploadResult> Upload(Track track, Stream stream)
        {
            var uploadResult = await _trackStore.Upload(track, stream);
            if (!uploadResult)
            {
                throw new Exception();
            }

            _trackRepository.Add(track);
            return new UploadResult(track.Id);
        }

        public void Upload()
        {

        }
    }
}
