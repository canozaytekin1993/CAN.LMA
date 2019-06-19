using System.Collections.Generic;
using System.Linq;
using CAN.LMA.WebUI.Data.Interfaces;
using CAN.LMA.WebUI.Data.Model;
using CAN.LMA.WebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CAN.LMA.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        [Route("Customer")]
        public IActionResult List()
        {
            var customerVM = new List<CustomerViewModel>();

            var customers = _customerRepository.GetAll();

            if (customers.Count() == 0) return View("Empty");

            foreach (var customer in customers)
                customerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = _bookRepository.Count(x => x.BorrowerId == customer.CustomerId)
                });

            return View(customerVM);
        }

        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);

            _customerRepository.Delete(customer);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerRepository.Create(customer);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var customer = _customerRepository.GetById(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _customerRepository.Update(customer);

            return RedirectToAction("List");
        }
    }
}