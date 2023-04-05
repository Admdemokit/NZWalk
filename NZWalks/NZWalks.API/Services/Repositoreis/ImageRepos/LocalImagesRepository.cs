using NZWalks.API.Data;
using NZWalks.API.Models.Domain.Imaging;
using NZWalks.API.Services.Interfaces.Images;

namespace NZWalks.API.Services.Repositoreis.ImageRepos
{
    public class LocalImagesRepository : IMageRepositories
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly NZWalksDbContext dbContext;

        public LocalImagesRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalksDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public async Task<Imagess> Upload(Imagess imagess)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images",
                $"{imagess.FileName}{imagess.FileExtension}");

            // Upload image To Local Storages
            using var stream = new FileStream(localFilePath, FileMode.Create);

            await imagess.File.CopyToAsync(stream);

            // https://localhost:1234/images/image.jpg
            // Save to drive
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{imagess.FileName}{imagess.FileExtension}";

            imagess.FilePath = urlFilePath;


            // Add ImagesPath  to the Tables Database
            await dbContext.Imagesses.AddAsync(imagess);
            await dbContext.SaveChangesAsync();

            return imagess;
        }
    }
}
