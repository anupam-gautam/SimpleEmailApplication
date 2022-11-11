namespace SimpleEmailApplication.Services.OtpGeneration
{
    public class OtpService : IOtpService
    {
        public string GenerateOtp()
        {
            var randomGenerator = new Random();
            int ranNumber = randomGenerator.Next(1, 10);
            return (ranNumber.ToString());
        }
    }
}
