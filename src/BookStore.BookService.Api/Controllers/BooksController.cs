using BookStore.BookService.DataAccess;
using BookStore.BookService.Design.Abstractions.DataAccess;
using BookStore.BookService.Design.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace BookStore.BookService.Api.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly IBookDao bookDao = new BookDao();
        [HttpGet, Route("{id}")]
        public Book GetBook(int id)
        {
            return bookDao.Get(id);
        }

        [HttpPost, Route("byIds")]
        public List<Book> GetBooks(List<int> ids)
        {
            return bookDao.Get(ids);
        }

        [HttpGet, Route("novelties")]
        public List<Book> GetNovelties()
        {
            return bookDao.GetNovelties();
        }
        [HttpGet, Route("popular")]
        public List<Book> GetPopular()
        {
            return bookDao.GetPopular();
        }

        [HttpGet, Route("withGenre/{id}")]
        public List<Book> GetWithGenre(int id)
        {
            return bookDao.GetWithGenre(id);
        }

    }
}
