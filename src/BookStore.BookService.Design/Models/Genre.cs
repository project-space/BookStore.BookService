using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BookService.Design.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String IllustrationUrl { get; set; }
    }
}
