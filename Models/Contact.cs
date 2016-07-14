using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WedMarch9.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public DateTime SendTime { get; set; }
        [Required]
        public string emailMessage { get; set; }
        [Required]
        public string phoneNumber { get; set; }
    }
}