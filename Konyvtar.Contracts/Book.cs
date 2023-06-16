using System.ComponentModel.DataAnnotations;
namespace Konyvtar.Contracts
{
    public class Book
    {

        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Author field is required!")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Title field is required!")]
        public string Title { get; set; }

        public string? Publisher { get; set; }
        public int? AccessionNumber { get; set; }
        public int? YearOfPublication { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }
        public string? NameOfBorrower { get; set; }

        public DateTime DateOfBorrowing { get; set; }

        //[ReturnDateValidation]
        public DateTime DateOfReturn { get; set; }


    }

}
