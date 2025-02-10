namespace AspMVCProject.Models
{
    public class mdlEmail
    {
        public string? smtpServer { get; set; } = "smtp.gmail.com";

        public int smtpPort { get; set; } = 587;

        public string? senderEmail { get; set; }

        public string? senderPassword { get; set; }

        public string? recipientEmail { get; set; }

        public string? subject { get; set; }

        public string? body { get; set; }

    }
}
