using BookStore.BookService.Design.Abstractions.DataAccess;
using System;
using System.Collections.Generic;
using BookStore.BookService.Design.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookService.DataAccess
{
    public class BookDao : IBookDao
    {
        private readonly string connectionString;

        public BookDao(IConnectionStringGetter getter)
        {
            this.connectionString = getter.Get();
        }

        public async Task<List<Book>> Get()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
               var books = await db.QueryAsync<Book>("SELECT * FROM RatingBook").ConfigureAwait(false);

               return books.ToList();
            }
        }

        public async Task<Book> Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var book = await db.QueryAsync<Book>("SELECT * FROM RatingBook where Id=@id",
                                                      new { id }).ConfigureAwait(false);
                return book.FirstOrDefault();
            }
        }

        public async Task<List<Book>> Get(List<int> ids)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                db.Execute(@"Create table #BookIds(
                             BookId int not null
                             )");
                using (SqlBulkCopy bulkCopy =
                           new SqlBulkCopy((SqlConnection)db))
                {
                    var dtable = CreateDataTable(ids);

                    bulkCopy.DestinationTableName = "#BookIds";
                    bulkCopy.WriteToServer(dtable);
                }

                var books = await db.QueryAsync<Book>(@"SELECT * FROM RatingBook where Id in 
                                                        (select BookId from #BookIds);
                                                        drop table BookIds;").ConfigureAwait(false);
                return books.ToList();

            }
        }

        public async Task<List<Book>> GetNovelties()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var novelties = await db.QueryAsync<Book>("SELECT top 4 * FROM RatingBook order by ReleaseDate desc ").ConfigureAwait(false);
                return novelties.ToList();
            }
        }

        public async Task<List<Book>> GetPopular()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var popular = await db.QueryAsync<Book>("SELECT top 4 * FROM RatingBook order by Rating desc ").ConfigureAwait(false);
                return popular.ToList();
            }
        }

        public async Task<List<Book>> GetWithGenre(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {   
                var booksWithGenre = await db.QueryAsync<Book>("select * from Book where GenreId=@id", new { id }).ConfigureAwait(false);
                return booksWithGenre.ToList();
            }
        }

        private DataTable CreateDataTable(List<int> ids)
        {
            DataTable table = new DataTable("BookIds");

            var column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "BookId";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            foreach (var id in ids)
            {
                var row = table.NewRow();
                row["BookId"] = id;
                table.Rows.Add(row);
            }

            return table;

        }

    }
}
