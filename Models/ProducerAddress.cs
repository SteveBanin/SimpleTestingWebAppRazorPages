namespace TestingWebAppRazorPages.Models
{
    public class ProducerAddress
    {
        public int ProducerAddressId { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public int Zipcode { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public int? ProducerId { get; set; }

        public Producer? Producers { get; set; }
    }
}
