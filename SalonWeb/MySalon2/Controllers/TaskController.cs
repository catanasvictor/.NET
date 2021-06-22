using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonWeb.BusinessLayer;
using SalonWeb.Data;


namespace SalonWeb.Views
{
    [Authorize]
    public class TaskController : Controller
    {
        private  ApplicationDbContext _context;
        private ITaskService taskService;

        private int appId;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
            taskService = new TaskService(context);
        }
        // GET: Tasks
        public async Task<IActionResult> Index(string searchString)
        {

            var tasks = taskService.GetTasks(includeProperties: "Appointment"); 

            return View(await tasks.ToListAsync());
        }

        // GET: Tasks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service =taskService.GetTask((int)id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            PopulateAppointmentsDropDownList();
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TaskName,Price,Id,AppointmentId")] DomainModel.Task service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    taskService.AddTask(service);   
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateAppointmentsDropDownList(service.AppointmentId);
            return View(service);
        }

        // GET: Tasks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = taskService.GetTask((int)id);
            if (service == null)
            {
                return NotFound();
            }
            PopulateAppointmentsDropDownList(service.AppointmentId);
            return View(service);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TaskName,Price,Id,AppointmentId")] DomainModel.Task service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  
                    taskService.UpdateTask(service);
                    return RedirectToAction(nameof(Index));

                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }

            }
           
            //ViewData["AppointmentId"] = new SelectList(_context.Appointment, "Id", "Id", service.AppointmentId);
            PopulateAppointmentsDropDownList(service.AppointmentId);
            return View(service);
        }

        // GET: Tasks/Delete/5
        public IActionResult  Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = taskService.GetTask((int)id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = taskService.GetTask((int)id);
            taskService.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }



        private void PopulateAppointmentsDropDownList(object selectedApp = null)
        {
          
            ViewBag.AppointmentId = new SelectList(_context.Appointment, "Id", "Data", selectedApp);
        }
    }
}
