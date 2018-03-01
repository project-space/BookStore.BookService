using BookStore.BookService.Design.Abstractions.DataAccess;
using BookStore.BookService.Design.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookStore.BookService.Api.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly IBookDao bookDao;

        public BooksController(IBookDao bookDao)
        {
            this.bookDao = bookDao;
        }

        [HttpGet, Route("{id}")]
        public async Task<Book> GetBook(int id)
        {
            return await bookDao.Get(id).ConfigureAwait(false);
        }

        [HttpPost, Route("byIds")]
        public async Task<List<Book>> GetBooks(List<int> ids)
        {
            return await bookDao.Get(ids).ConfigureAwait(false);
        }

        [HttpGet, Route("novelties")]
        public async Task<List<Book>> GetNovelties()
        {
            return await bookDao.GetNovelties().ConfigureAwait(false);
        }

        [HttpGet, Route("popular")]
        public async Task<List<Book>> GetPopular()
        {
            return await bookDao.GetPopular().ConfigureAwait(false);
        }

        [HttpGet, Route("withGenre/{id}")]
        public async Task<List<Book>> GetWithGenre(int id)
        {
            return await bookDao.GetWithGenre(id).ConfigureAwait(false);
        }

    }
}
