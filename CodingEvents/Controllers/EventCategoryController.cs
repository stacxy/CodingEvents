﻿using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventCategoryController : Controller
    { 

        private EventDbContext context;


    public EventCategoryController(EventDbContext dbContext)
    {
        context = dbContext;
    }

        // GET: /<controller>/
       [HttpGet]
       
        public IActionResult Index()
        {
            List<EventCategory> eventCategories = context.Categories.ToList();

            return View(eventCategories);
        }

        // GET: /EventCategory/Create
        [HttpGet]
     
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        [Route("/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newEventCategory = new EventCategory()
                {
                    Name = addEventCategoryViewModel.Name
                };

                context.Categories.Add(newEventCategory);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }

            return View("Create", addEventCategoryViewModel);
        }

    }
}
