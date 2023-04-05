using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain.Imaging
{
    public class Imagess
    {
        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; }
        public long FileSizeinByte { get; set; }
        public string FilePath { get; set; }
    }
}
