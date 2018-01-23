using BookStore.BookService.Design.Abstractions.DataAccess;
using System;
using System.Collections.Generic;
using BookStore.BookService.Design.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace BookStore.BookService.DataAccess
{
    public class BookDao : IBookDao
    {
        private readonly string connectionString;

        public BookDao(IConnectionStringGetter getter)
        {
            this.connectionString = getter.Get();
        }

        public List<Book> Get()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
               return db.Query<Book>("SELECT * FROM RatingBook").ToList();
            }
        }

        public Book Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Book>("SELECT * FROM RatingBook where Id=@id", new { id }).FirstOrDefault();
            }
        }

        public List<Book> Get(List<int> ids)
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

                return db.Query<Book>(@"SELECT * FROM RatingBook where Id in (select BookId from #BookIds);
                                        drop table BookIds;").ToList();
            }
        }

        public List<Book> GetNovelties()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Book>("SELECT top 15 * FROM RatingBook order by ReleaseDate desc ").ToList();
            }
        }

        public List<Book> GetPopular()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Book>("SELECT top 15 * FROM RatingBook order by Rating desc ").ToList();
            }
        }

        public List<Book> GetWithGenre(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                
                return db.Query<Book>("select * from Book where GenreId=@id", new { id }).ToList();
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
