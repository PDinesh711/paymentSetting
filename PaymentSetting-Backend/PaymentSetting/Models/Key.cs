using System.ComponentModel.DataAnnotations;

namespace PaymentSetting.Models
{
    public class Key
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public string KeyID { get; set; }
        [Required]
        public string Keyvalue { get; set; }
    } 
}
