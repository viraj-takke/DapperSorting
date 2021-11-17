using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Enter valid Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Enter City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}