namespace AspMVCProject.Models
{
    public class mdlQrCoder
    {
        public int QrCodeType { get; set; }

        public string? ImageUrl { get; set; }

        public string? smsPhoneNumber { get; set; }

        public string? smsBody { get; set; }

        public string? wapNumber { get; set; }

        public string? wapMessage{ get; set; }

        public string? Email { get; set; }

        public string? EmailSubject { get; set; }

        public string? EmailBody{ get; set; }

        public string? wifiName { get; set; }
        public string? wifiPassword { get; set; }

        public string? QrImageUrl { get; set; }

    }
}
