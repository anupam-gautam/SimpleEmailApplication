using System.ComponentModel.DataAnnotations;

namespace SimpleEmailApplication.Models
{
    public class EmailDto
    {
        [Key]
        public int Id { get; set;}
        private string? otp;
        public string To { get; set; }
        public string? Subject { get; set; } 
        public string? Body { get; set; }
        public string? OTP { get; set; }

    }
}
