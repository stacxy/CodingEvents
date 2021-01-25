using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter a description")]
        [StringLength(500)]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }
    }
}
