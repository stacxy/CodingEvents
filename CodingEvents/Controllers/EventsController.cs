using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;
using CodingEvents.Data;
using CodingEvents.ViewModels;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    { 

        //GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>( EventData.GetAll());

            return View(events);
        }

   
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event()
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Location = addEventViewModel.Location,
                    NumberOfAttendees = addEventViewModel.NumberOfAttendees,
                    Type = addEventViewModel.Type,
                    Registration = addEventViewModel.Registration
                };

                EventData.Add(newEvent);

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.Events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Edit/{EventId}")]
        public IActionResult Edit(int eventId)
        {
            
            Event model = EventData.GetById(eventId);
            ViewBag.Event = model;
            ViewBag.Title = $"Edit event {model.Name} {model.Id}";
            return View();
        }

        [HttpPost]
        [Route ("/Events/Edit/")]
        public IActionResult SubmitEditEventForm(string name, string description, int eventId)
        {
            Event model = EventData.GetById(eventId);
            model.Name = name;
            model.Description = description;

            return Redirect("/Events");
        }

        

    }
}
