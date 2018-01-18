using BookStore.BookService.Design.Abstractions.DataAccess;
using System;
using System.Collections.Generic;
using BookStore.BookService.Design.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

public class GenreDao : IGenreDao
{
    static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore.Book;Integrated Security=True;";

    public Genre GetGenre(int id)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<Genre>("SELECT * FROM Genre where Id=@id", new{ id }).FirstOrDefault();
        }
    }

    public List<Genre> GetAll()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<Genre>("SELECT * FROM Genre").ToList();
        }
    }
}

