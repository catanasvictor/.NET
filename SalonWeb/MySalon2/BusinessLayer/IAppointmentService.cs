using SalonWeb.DomainModel;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace SalonWeb.BusinessLayer
{
    interface IAppointmentService
    {
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int id);
        void DeleteAppointment(Appointment appointment);
        Appointment GetAppointment(int id);
        IQueryable<Appointment> GetAppointments(Expression<Func<Appointment, bool>> filter = null, Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>> orderBy = null, string includeProperties = "");

    }
}
