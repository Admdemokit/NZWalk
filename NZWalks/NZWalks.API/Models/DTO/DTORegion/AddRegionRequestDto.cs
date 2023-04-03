using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.DTORegion
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code Has to be a minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code Has to be a maximum of 3 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name Has to be a Maximum of 100 characters")]
        public string Name { get; set; }
        public string? RegionImgUrl { get; set; }
    }
}
