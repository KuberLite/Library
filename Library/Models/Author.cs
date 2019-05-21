using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author
    {
        [Key]
        public string AuthorId { get; set; }

        public int AuthorNumber { get; set; }

        [MaxLength(20)]
        public string AuthorLastName { get; set; }
    }
}
