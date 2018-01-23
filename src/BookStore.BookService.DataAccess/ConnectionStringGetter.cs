using BookStore.BookService.Design.Abstractions.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BookService.DataAccess
{
    public class ConnectionStringGetter : IConnectionStringGetter
    {
        public string Get()
        {
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore.Book;Integrated Security=True;";
        }
    }
}
