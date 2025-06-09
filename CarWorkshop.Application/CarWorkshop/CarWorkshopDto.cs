using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
    public record CarWorkshopDto(
        [Required]
        [StringLength(20, MinimumLength = 2)]
        string Name,
        [Required]
        string? Description,
        string? About,
        [Phone]
        [StringLength(12, MinimumLength = 8)]
        string? PhoneNumber,
        string? Street,
        string? City,
        string? PostalCode,
        string? EncodedName
    );
}
