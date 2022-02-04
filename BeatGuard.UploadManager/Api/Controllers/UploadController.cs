using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using BeatGuard.UploadManager.Api.Extensions;
using BeatGuard.UploadManager.Api.Models;
using BeatGuard.UploadManager.Api.Validators;
using BeatGuard.UploadManager.Domain.Entities;
using BeatGuard.UploadManager.Domain.Services;
using BeatGuard.UploadManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BeatGuard.UploadManager.Api.Controllers
{
    [Route("api/[controller]")]
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
        [Route("upload")]
        public async Task<JsonResult> Post()
        {
            var fileName = Request.Form.Files.First().FileName;
            var fileStream = Request.Form.Files.FirstOrDefault()?.OpenReadStream();
            var request = new UploadRequest("", fileStream);
            var validate = new UploadRequestValidator().Validate(request);
            if (!validate.IsValid)
            {
                return this.JSendFail(validate.Errors);
            }

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
