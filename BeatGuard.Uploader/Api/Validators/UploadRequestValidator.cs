using BeatGuard.Uploader.Api.Models;
using FluentValidation;

namespace BeatGuard.Uploader.Api.Validators
{
    public class UploadRequestValidator : AbstractValidator<UploadRequest>
    {
        public UploadRequestValidator()
        {
            RuleFor(x => x.Stream).Cascade(CascadeMode.StopOnFirstFailure).NotNull().WithMessage("Track invalid.").Must(x => x.Length < 8e+7).WithMessage("Track file size to large.");
            RuleFor(x => x.AccessToken).NotEmpty().WithMessage("Invalid access token.");
        }

        /*public bool Validate2(UploadRequest request)
        {
            if (Request.Form.Files.First().Length > 8e+7)
            {
                return new JsonResult("error: file size exceeds 80MB");
                // file size validation
            }

            var buffer = new byte[4];
            var startBytes = Request.Form.Files.First().OpenReadStream().Read(buffer);
            var fileType = AudioTypeService.Detect(buffer);
            if (fileType == AudioType.Invalid)
            {
                return new JsonResult();
            }
            // file type validation 
        }*/
    }
}
