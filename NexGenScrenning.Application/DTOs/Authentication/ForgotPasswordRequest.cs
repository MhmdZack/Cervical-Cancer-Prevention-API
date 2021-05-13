using System.ComponentModel.DataAnnotations;

namespace NexGenScreening.Application.DTOs.Authentication
{
    public class ForgotPasswordRequest
    {
        [Required]
        public string UserName { get; set; }
    }
}
