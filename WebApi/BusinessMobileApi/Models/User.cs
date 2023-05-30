using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessMobileApi.Models
{
    public class User
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        public int number { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public int? hasMonthStores { get; set; }

    }
}
