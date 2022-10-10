namespace SimpleEmailApplication
{
    public class DbInfoResponseDto
    {
        public List<EmailOtp> EmailOtps { get; set; } = new List<EmailOtp>();
        public int Pages { get; set; }
        public int CurrentPages { get; set; }
    }
}
