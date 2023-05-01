using System.ComponentModel.DataAnnotations;

namespace TestingWebAppRazorPages.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string? MovieTitle { get; set; }

        public string? MovieCategory { get; set; }

        [DataType(DataType.Date)]
        public DateTime MovieRelaesedDate { get; set; }

        public TimeSpan? MovieDuration { get; set; }


        #region Navigation Property

        public virtual ICollection<Producer>? Producers { get; set; }

        #endregion
    }
}
