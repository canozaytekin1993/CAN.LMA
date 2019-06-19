using System.Collections.Generic;
using CAN.LMA.WebUI.Data.Model;

namespace CAN.LMA.WebUI.ViewModel
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}