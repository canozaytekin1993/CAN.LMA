using System;
using System.Collections.Generic;
using System.Linq;
using CAN.LMA.WebUI.Data.Interfaces;
using CAN.LMA.WebUI.Data.Model;
using CAN.LMA.WebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CAN.LMA.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        [Route("Book")]
        public IActionResult List(int? authorId, int? borrowerId)
        {
            if (authorId == null && borrowerId == null)
            {
                // show all you.
                var books = _bookRepository.GetAllWithAuthor();
                // check books.
                CheckBooks(books);
            }
            else if (authorId != null)
            {
                // filter by author id
                var author = _authorRepository.GetWithBook((int) authorId);
                // check auther books.
                if (author.Books.Count() == 0)
                    return View("Empty");
                return View("EmptyAuthor", author);
            }
            else if (borrowerId != null)
            {
                // filter by borrow id
                var books = _bookRepository.FindWithAuthorAndBorrower(x => x.BorrowerId == borrowerId);
                // check borrower
                CheckBooks(books);
            }
            else
            {
                // throw exception
                throw new ArgumentException();
            }

            return null;
        }

        public IActionResult CheckBooks(IEnumerable<Book> books)
        {
            if (books.Count() == 0)
                return View("Empty");
            return View(books);
        }

        public IActionResult Create()
        {
            var bookVM = new BookViewModel
            {
                Authors = _authorRepository.GetAll()
            };
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            _bookRepository.Create(bookViewModel.Book);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var bookVM = new BookViewModel
            {
                Book = _bookRepository.GetById(id),
                Authors = _authorRepository.GetAll()
            };
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Update(BookViewModel bookViewModel)
        {
            _bookRepository.Update(bookViewModel.Book);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);

            _bookRepository.Delete(book);

            return RedirectToAction("List");
        }
    }
}