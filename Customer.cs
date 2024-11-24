using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CustomerNumber { get; set; }

        [MaxLength(255)]
        public string CustomerName { get; set; }

        public DateOnly DateOfBirth { get; set; }

        [MaxLength(1)]
        public string Gender { get; set; }

    }
}
