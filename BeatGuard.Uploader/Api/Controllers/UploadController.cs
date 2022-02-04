using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using BeatGuard.Uploader.Api.Extensions;
using BeatGuard.Uploader.Api.Models;
using BeatGuard.Uploader.Api.Validators;
using BeatGuard.Uploader.Domain.Entities;
using BeatGuard.Uploader.Domain.Services;
using BeatGuard.Uploader.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeatGuard.Uploader.Api.Controllers
{
    [Route("upload")]
    [ApiController]
    public class UploadController : Controller
    {
        private readonly TrackService _trackService;
        private readonly AuthService _authService;
        private readonly TrackMetaService _trackMetaService;

        public UploadController(TrackService trackService, AuthService authService, TrackMetaService trackMetaService)
        {
            _trackService = trackService;
            _authService = authService;
            _trackMetaService = trackMetaService;
        }

        [HttpPost]
        public async Task<JsonResult> Post()
        {
            var fileName = Request.Form.Files.First().FileName;
            var fileStream = Request.Form.Files.FirstOrDefault()?.OpenReadStream();
            var request = new UploadRequest(Request.Form.FirstOrDefault(x => x.Key == "access_token").Value, fileStream);
            var validate = new UploadRequestValidator().Validate(request);
            if (!validate.IsValid)
            {
                return this.JSendFail(validate.Errors);
            }

            Console.WriteLine(request.AccessToken);

            User user;
            try
            {
                user = _authService.Authenticate(request.AccessToken);
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine(e);
                return this.JSendError("Access token invalid.");
            }

            TrackMeta trackMeta;
            try
            {
                trackMeta = _trackMetaService.Read(request.Stream, fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return this.JSendError("Invalid file type.");
            }

            var track = Track.Create(trackMeta.FileName, trackMeta.BitRate, trackMeta.Duration, trackMeta.Type, user.Id);
            try
            {
                var result = await _trackService.Upload(track, request.Stream);
                return this.JSendSuccess(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return this.JSendError("Uploaded failed.");
            }
        }
    }
}
