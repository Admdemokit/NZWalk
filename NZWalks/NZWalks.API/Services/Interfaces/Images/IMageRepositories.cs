using NZWalks.API.Models.Domain.Imaging;

namespace NZWalks.API.Services.Interfaces.Images
{
    public interface IMageRepositories
    {
        Task<Imagess> Upload(Imagess imagess);
    }
}
