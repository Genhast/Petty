using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Petty.Models
{
    public class BooksModel
    {
        [Key]
        public int Book_Id { get; set; }
        public string Book_Title { get; set; }
        public string Book_Description { get; set; }
        public string Book_Author { get; set; }
        public int Book_Amount { get; set; }
        public float Book_Price { get; set; }
    }
}
