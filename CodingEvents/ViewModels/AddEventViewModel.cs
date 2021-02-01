using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage ="Please enter the location")]
        public string Location { get; set; }

        [Required(ErrorMessage ="Please enter a number")]
        [Range(0, 100000, ErrorMessage ="Invalid entry")]
        public int NumberOfAttendees { get; set; }

        public EventType Type { get; set; }

        public bool IsTrue { get { return true; } }

        [Compare("IsTrue", ErrorMessage = "Attendee registration is required")]
        public bool Registration { get; set; }

        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
            new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
            new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
            new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString())
        };
    }
}
