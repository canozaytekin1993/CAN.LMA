using System.Collections.Generic;
using CAN.LMA.WebUI.Data.Model;

namespace CAN.LMA.WebUI.Data.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAllWithBook();
        Author GetWithBook(int id);
    }
}