using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.CuraHub.IdentitySection.IdentitySectionVM
{
    public class RegisterVM
    {
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        [RegularExpression("/^[a-zA-Z]{3,50}$/")]
        public string FirstName { get; set; } = null!;
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        [RegularExpression("/^[a-zA-Z]{3,50}$/")]
        public string LastName { get; set; } = null!;
        
        public string? ProfilePicture { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

    }
}
