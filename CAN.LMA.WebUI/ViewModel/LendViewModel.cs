using System.Collections.Generic;
using CAN.LMA.WebUI.Data.Model;

namespace CAN.LMA.WebUI.ViewModel
{
    public class LendViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}