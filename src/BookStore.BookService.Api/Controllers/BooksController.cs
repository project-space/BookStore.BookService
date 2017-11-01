using BookStore.BookService.Design.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace BookStore.BookService.Api.Controllers
{
    public class BooksController : ApiController
    {
        public List<Book> Get()
        {
            return new List<Book>
            {
                new Book
                {
                    Author = "Эрих Мария Ремарк",
                    Title = "Три товарища",
                    Description = "Все равно в конце все сдохнут.",
                    Price = 600.50m,
                    Id = 1
                },
                new Book
                {
                    Author = "Мария Семенова",
                    Title = "Волкодав",
                    Description = "Шедевр всех времен и народов.",
                    Price = 600,
                    Id = 2
                },
                new Book
                {
                    Author = "Джек Лондон",
                    Title = "Мартин Иден",
                    Description = "Он утопится.",
                    Price = 700,
                    Id = 3
                },
                new Book
                {
                    Author = "Чак Паланик",
                    Title = "Бойцовский клуб",
                    Description = "вере из май майнд",
                    Price = 900,
                    Id = 4
                },
                new Book
                {
                    Author = "Рэй Брэдбери",
                    Title = "Лёд и пламя",
                    Description = "Не про Тома и Джерри, как ни странно.",
                    Price = 800,
                    Id = 5
                }
            };
        }
    }
}
