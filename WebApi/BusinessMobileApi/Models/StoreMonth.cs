using System.ComponentModel.DataAnnotations;

namespace BusinessMobileApi.Models
{
    public class StoreMonth
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int number { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string date { get; set; }
        [Required]
        public string sdate { get; set; }
        [Required]
        public string gdate { get; set; }
        [Required]
        public string dname { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required]
        public int idc { get; set; }
    }
}
