using BookStore.BookService.Design.Models;
using System.Collections.Generic;

namespace BookStore.BookService.Design.Abstractions.DataAccess
{
    public interface IBookDao
    {
        List<Book> Get();
        Book Get(int id);
        List<Book> Get(List<int> ids);
        List<Book> GetNovelties();
        List<Book> GetPopular();
        List<Book> GetWithGenre(int id);
    }
}
