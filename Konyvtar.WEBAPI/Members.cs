using System.ComponentModel.DataAnnotations;
namespace Konyvtar.WEBAPI
{
    public class Members
    {
        [Key]
        public int MemberID { get; set; }

        [Required]
        public string MemberName { get; set; }

        [Required]

        public string Address { get; set; }

        [Required]

        public DateTime BirthDate { get; set; }

        
    }
}
