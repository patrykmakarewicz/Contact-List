using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Shared
{
    public class Contact
    {   
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
       
        public string CategoryDescription { get; set; } = string.Empty;
    }

 
}
