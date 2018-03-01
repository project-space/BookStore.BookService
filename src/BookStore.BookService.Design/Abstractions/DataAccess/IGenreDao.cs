using BookStore.BookService.Design.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BookService.Design.Abstractions.DataAccess
{
    public interface IGenreDao
    {
        Task<Genre> GetGenre(int id);
        Task<List<Genre>> GetAll();
    }
}
