using CAN.LMA.WebUI.Data.Interfaces;
using CAN.LMA.WebUI.Data.Model;

namespace CAN.LMA.WebUI.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryManagementDbContext context) : base(context)
        {
        }
    }
}