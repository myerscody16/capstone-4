using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone4.Controllers
{
    public class TaskListController : Controller
    {
        private readonly TaskListCapstone4DbContext _context;

        public TaskListController(TaskListCapstone4DbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult AddTask()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddTask(Tasks newTask)
        {
            AspNetUsers thisUser = _context.AspNetUsers.Where(x => x.UserName == User.Identity.Name).First();
            newTask.UserId = thisUser.Id;
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
            List<Tasks> listOfTasks = _context.Tasks.ToList();
            ViewBag.listOfTasks = listOfTasks;
            return RedirectToAction("ViewTaskList");
        }
        public IActionResult ViewTaskList()
        {
            return View();
        }
    }
}