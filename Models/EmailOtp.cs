using System;
using System.Collections.Generic;

namespace SimpleEmailApplication.Models
{
    public partial class EmailOtp
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Otp { get; set; }
    }
}
