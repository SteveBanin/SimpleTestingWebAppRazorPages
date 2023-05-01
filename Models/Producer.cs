namespace TestingWebAppRazorPages.Models
{
    public class Producer
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Category { get; set; }


        #region Navigation Property

        public ProducerAddress? Adress { get; set; }

        public virtual ICollection<Movie>? Movies { get; set; }

        #endregion
    }
}
