using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain.Imaging;
using NZWalks.API.Models.DTO.DTOIMage;
using NZWalks.API.Services.Interfaces.Images;

namespace NZWalks.API.Controllers.ImageControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMageRepositories imageRepositories;

        public ImagesController(IMageRepositories imageRepositories)
        {
            this.imageRepositories = imageRepositories;
        }

        // POST: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                // Convert DTO to Domain model
                var imageDomainModel = new Imagess
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeinByte = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,

                };

                // User repository to upload image
                await imageRepositories.Upload(imageDomainModel);
                return Ok(imageDomainModel);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, Please upload smaller size file");
            }
        }
    }
}
