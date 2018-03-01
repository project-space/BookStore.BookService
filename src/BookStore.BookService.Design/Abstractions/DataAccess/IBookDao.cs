using BookStore.BookService.Design.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.BookService.Design.Abstractions.DataAccess
{
    public interface IBookDao
    {
        Task<List<Book>> Get();
        Task<Book> Get(int id);
        Task<List<Book>> Get(List<int> ids);
        Task<List<Book>> GetNovelties();
        Task<List<Book>> GetPopular();
        Task<List<Book>> GetWithGenre(int id);
    }
}
