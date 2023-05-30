using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessMobileApi.Models
{
    public class Store
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public int number { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string ip { get; set; }
        [Required]
        public int connected { get; set; }
        [Required]
        public int seller { get; set; }
        [Required]
        public decimal paidAmount { get; set; }
        [Required]
        public decimal unpaidAmount { get; set; }
    }
}
