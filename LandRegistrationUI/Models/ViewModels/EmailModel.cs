using System.ComponentModel.DataAnnotations;

namespace LandRegistrationUI.Models.ViewModels
{
    public class EmailModel
    {
        [Required]
        public string ToMailId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public System.IO.Stream File { get; set; }
        public string FileName { get; set; }
    }
}