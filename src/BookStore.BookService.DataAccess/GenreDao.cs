using BookStore.BookService.Design.Abstractions.DataAccess;
using System.Collections.Generic;
using BookStore.BookService.Design.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

public class GenreDao : IGenreDao
{
    private readonly string connectionString;

    public GenreDao(IConnectionStringGetter getter)
    {
        this.connectionString = getter.Get();
    }

    public async Task<Genre> GetGenre(int id)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var genre = await db.QueryAsync<Genre>("SELECT * FROM Genre where Id=@id", new{ id }).ConfigureAwait(false);
            return genre.FirstOrDefault();
        }
    }

    public async Task<List<Genre>> GetAll()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var genres = await db.QueryAsync<Genre>("SELECT * FROM Genre").ConfigureAwait(false);
            return genres.ToList();
        }
    }
}

