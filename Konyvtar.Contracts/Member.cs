using System.ComponentModel.DataAnnotations;
namespace Konyvtar.Contracts
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        [MemberNameValidation]
        public string MemberName { get; set; }

        [Required]

        public string Address { get; set; }

        [Required]

        public DateTime BirthDate { get; set; }

        
    }
}
