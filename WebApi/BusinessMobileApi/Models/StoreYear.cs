using System.ComponentModel.DataAnnotations;

namespace BusinessMobileApi.Models
{
    public class StoreYear
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int number { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string smonth { get; set; }
        [Required]
        public string mname { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required]
        public int idc { get; set; }
    }
}
