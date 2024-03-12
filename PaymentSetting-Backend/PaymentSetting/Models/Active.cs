using System.ComponentModel.DataAnnotations;

namespace PaymentSetting.Models
{
    public class Active
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Result { get; set; }
    }
}
