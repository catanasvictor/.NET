using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonWeb.BusinessLayer;
using SalonWeb.Data;
using SalonWeb.DomainModel;
using SalonWeb.Exporter;

namespace SalonWeb.Views
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IAppointmentService appointmentService;
        private ExporterFactory creator = new ExporterFactory();


        public AppointmentController(ApplicationDbContext context)
        {
            appointmentService = new AppointmentService(context);       
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Data,ClientName,PhoneNumber,Cost,Id")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointmentService.AddAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET
        public async Task<IActionResult> Index(string searchString)
        {
            var appointments =  appointmentService.GetAppointments();

            if (!String.IsNullOrEmpty(searchString))
            {
                appointments = appointments.Where(s => s.ClientName.Contains(searchString));
            }

            return View( await appointments.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment =  appointmentService.GetAppointment((int)id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = appointmentService.GetAppointment((int)id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Data,ClientName,PhoneNumber,Cost,Id")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    appointmentService.UpdateAppointment(appointment);
                    return RedirectToAction(nameof(Index));

                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                
            }
            return View(appointment);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = appointmentService.GetAppointment((int)id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = appointmentService.GetAppointment((int)id);
            appointmentService.DeleteAppointment(id);
            return RedirectToAction(nameof(Index));
        }

        // GET
        public IActionResult Export()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Export(int exp)
        {
            var appointments = appointmentService.GetAppointments();
            IExporter exporter = creator.createExporter(exp);
            exporter.exportFile(appointments.ToList());
            return View();
        }


    }
}
