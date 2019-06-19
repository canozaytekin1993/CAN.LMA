using System;
using System.Collections.Generic;
using System.Linq;
using CAN.LMA.WebUI.Data.Interfaces;
using CAN.LMA.WebUI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CAN.LMA.WebUI.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _context.Books.Include(x => x.Author);
        }

        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(x => x.Author)
                .Where(predicate);
        }

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            return _context.Books.Include(x => x.Author).Include(x => x.Borrower).Where(predicate);
        }
    }
}