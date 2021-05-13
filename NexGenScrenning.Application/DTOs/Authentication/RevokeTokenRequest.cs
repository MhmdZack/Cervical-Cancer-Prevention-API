using System.ComponentModel.DataAnnotations;

namespace NexGenScreening.Application.DTOs.Authentication
{
    public class RevokeTokenRequest
    {
        [Required(ErrorMessage = "Token is Required")]
        public virtual string Token { get; set; }
    }
}
