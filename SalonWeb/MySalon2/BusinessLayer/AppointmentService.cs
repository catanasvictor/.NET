using SalonWeb.DataAccessLayer;
using SalonWeb.Data;
using SalonWeb.DomainModel;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SalonWeb.BusinessLayer
{
    public class AppointmentService : IAppointmentService 
      
    {
        IUnitOfWork unitOfWork;
        public AppointmentService(ApplicationDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }
    
        public void AddAppointment(Appointment appointment)
        {
            unitOfWork.AppointmentsRepository.Insert(appointment);
            unitOfWork.Save();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            unitOfWork.AppointmentsRepository.Update(appointment);
            unitOfWork.Save();
        }

        public void DeleteAppointment(int id)
        {
            unitOfWork.AppointmentsRepository.Delete(id);
            unitOfWork.Save();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            unitOfWork.AppointmentsRepository.Delete(appointment);
            unitOfWork.Save();
        }

        public Appointment GetAppointment(int id)
        {
            Appointment appointment = unitOfWork.AppointmentsRepository.GetByID(id);
            if (appointment != null)
            {
                return appointment;
            }
            return null;
        }

        public virtual IQueryable<Appointment> GetAppointments(Expression<Func<Appointment, bool>> filter = null, Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>> orderBy = null, string includeProperties = "")
        {
           return unitOfWork.AppointmentsRepository.Get(filter, orderBy, includeProperties);
        }

    }
}
