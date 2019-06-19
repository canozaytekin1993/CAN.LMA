using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAN.LMA.WebUI.Data.Model
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        [RegularExpression("Some-crazy-regex")]
        public string Phone { get; set; }

        [EmailAddress] public string Email { get; set; }
    }
}