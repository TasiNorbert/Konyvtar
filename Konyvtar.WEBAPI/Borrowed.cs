using System.ComponentModel.DataAnnotations;
namespace Konyvtar.WEBAPI
{
    public class Borrowed
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public int MemberId { get; set; }

        public DateTime DateOfBorrowing { get; set; }

        public DateTime DateOfReturn { get; set; }
    }
}
