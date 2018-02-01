namespace HotwireCarStalker.Configuration
{
    public class Email
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public string AlertEmailTo { get; set; }
        public string AlertEmailFrom { get; set; }
        public string AlertEmailSubject { get; set; }
    }
}