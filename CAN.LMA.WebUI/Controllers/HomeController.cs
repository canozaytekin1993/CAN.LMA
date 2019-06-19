using System.Diagnostics;
using CAN.LMA.WebUI.Data.Interfaces;
using CAN.LMA.WebUI.Models;
using CAN.LMA.WebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CAN.LMA.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(IBookRepository bookRepository, IAuthorRepository authorRepository,
            ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            // create home view model
            var homeVM = new HomeViewModel
            {
                AuthorCount = _authorRepository.Count(X => true),
                CustomerCount = _customerRepository.Count(x => true),
                BookCount = _bookRepository.Count(x => true),
                LendBookCount = _bookRepository.Count(x => x.Borrower != null)
            };

            // call view
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}