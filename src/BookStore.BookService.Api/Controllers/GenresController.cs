using BookStore.BookService.DataAccess;
using BookStore.BookService.Design.Abstractions.DataAccess;
using BookStore.BookService.Design.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace BookStore.BookService.Api.Controllers
{
    [RoutePrefix("api/genres")]
    public class GenresController : ApiController
    {
        private readonly IGenreDao genreDao;

        public GenresController(IGenreDao genreDao)
        {
            this.genreDao = genreDao;
        }

        [Route("genres/{id}")]
        public Genre GetGenre(int id)
        {
            return genreDao.GetGenre(id);
        }
        [Route("genres")]
        public List<Genre> GetGenre()
        {
            return genreDao.GetAll();
        }
    }
}
