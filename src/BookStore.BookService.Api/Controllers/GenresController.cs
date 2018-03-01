using BookStore.BookService.Design.Abstractions.DataAccess;
using BookStore.BookService.Design.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<Genre> GetGenre(int id)
        {
            return await genreDao.GetGenre(id).ConfigureAwait(false);
        }

        [Route("genres")]
        public async Task<List<Genre>> GetGenre()
        {
            return await genreDao.GetAll().ConfigureAwait(false);
        }
    }
}
