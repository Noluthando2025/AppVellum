
using System.ComponentModel.DataAnnotations;

namespace AppVellum.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(150)]
        public string CompanyName { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Website { get; set; }

        [StringLength(100)]
        public string? Industry { get; set; }
    }
}
