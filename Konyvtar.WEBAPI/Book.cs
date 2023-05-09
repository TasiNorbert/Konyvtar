using System.ComponentModel.DataAnnotations;
namespace Konyvtar.WEBAPI
{
    public class Book
    {

 
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Author field is required!")]
            public string Author { get; set; }

            [Required(ErrorMessage = "Title field is required!")]
            public string Title { get; set; }

            [Required]
            public bool IsBorrowed { get; set; }

            
            public string? NameOfBorrower { get; set; }

            public DateTime? DateOfBorrowing { get; set; }

            
            public DateTime? DateOfReturn { get; set; }

        }
    
}
