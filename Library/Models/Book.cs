using System.ComponentModel.DataAnnotations;
namespace Library.Models
{
    public class Book
    {
        public string BookId { get; set; }

        public int BookNumber { get; set; }

        [MaxLength(30)]
        public string BookName { get; set; }

        public int ReleaseYear { get; set; }

        public int AuthorNumber { get; set; }

        [MaxLength(20)]
        public string AuthorLastName { get; set; }
    }
}
