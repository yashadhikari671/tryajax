using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tryajax.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Required] //make this field required
        [StringLength(50)] // adds character limit = 50
        public string Name { get; set; }

        [Required] // make this field required
        [EmailAddress] // Validates that the property has an email format.
        public string Email { get; set; }
    }
}
