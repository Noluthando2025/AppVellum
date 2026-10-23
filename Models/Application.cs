
using System;
using System.ComponentModel.DataAnnotations;

namespace AppVellum.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(150)]
        public string JobTitle { get; set; } = string.Empty;

        public DateTime? DateApplied { get; set; }

        [Required]
        [RegularExpression(
            "^(Saved|Applied|Assessment|Interview|Offer|Rejected|Withdrawn)$",
            ErrorMessage = "Please select a valid application status."
        )]
        public string Status { get; set; } = "Saved";

        [StringLength(100)]
        public string? JobType { get; set; }

        [StringLength(150)]
        public string? Location { get; set; }

        [Url]
        public string? ApplicationLink { get; set; }

        [StringLength(2000)]
        public string? Notes { get; set; }
    }
}
