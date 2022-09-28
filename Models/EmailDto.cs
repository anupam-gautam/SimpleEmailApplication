namespace SimpleEmailApplication.Models
{
    public class EmailDto
    {

        private string otp;
        public string To { get; set; }
        public string Subject { get; set; } 
        public string Body { get; set; }
        public string OTP
        {
            get{
                return otp;
            }
            set{
                var randomGenerator = new Random();
                int ranNumber = randomGenerator.Next(1, 10);
                otp = ranNumber.ToString();
            }
        }

    }
}
