
using System.ComponentModel.DataAnnotations;

namespace AppVellum.ViewModels
{
    // Holds the information submitted when a user creates a job application.
    public class CreateApplicationViewModel
    {
        [Required]
        [StringLength(150)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a company name.")]
        [StringLength(150)]
        [Display(Name = "Company")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [RegularExpression(
            "^(Saved|Applied|Interview|Assessment|Offer|Rejected|Withdrawn)$",
            ErrorMessage = "Please select a valid application status."
        )]
        public string Status { get; set; } = "Saved";

        public DateTime? DateApplied { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public DateTime? InterviewDate { get; set; }
        public DateTime? FollowUpDate { get; set; }

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
