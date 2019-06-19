using System.Collections.Generic;
using System.Linq;
using CAN.LMA.WebUI.Data.Interfaces;
using CAN.LMA.WebUI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CAN.LMA.WebUI.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<Author> GetAllWithBook()
        {
            return _context.Authors.Include(x => x.Books);
        }

        public Author GetWithBook(int id)
        {
            return _context.Authors
                .Where(x => x.AuthorId == id)
                .Include(x => x.Books)
                .FirstOrDefault();
        }
    }
}