using SalonWeb.DataAccessLayer;
using SalonWeb.Data;
using SalonWeb.DomainModel;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace SalonWeb.BusinessLayer
{
    public class TaskService : ITaskService
    {
        IUnitOfWork unitOfWork;
       
        public TaskService(ApplicationDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public TaskService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddTask(DomainModel.Task service)
        {
            unitOfWork.TasksRepository.Insert(service);
            unitOfWork.Save();
            this.UpdateCost(service.AppointmentId);

        }
        public void UpdateTask(DomainModel.Task service)
        {
            unitOfWork.TasksRepository.Update(service);
            unitOfWork.Save();
            this.UpdateCost(service.AppointmentId);
        }

        public void DeleteTask(int id)
        {
            var appId = unitOfWork.TasksRepository.GetByID(id).AppointmentId;
            unitOfWork.TasksRepository.Delete(id);
            unitOfWork.Save();
            this.UpdateCost(appId);
        }

        public void DeleteTaask(DomainModel.Task task)
        {
            unitOfWork.TasksRepository.Delete(task);
            unitOfWork.Save();
        }

        public DomainModel.Task GetTask(int id)
        {
            DomainModel.Task service = unitOfWork.TasksRepository.GetByID(id);
            if (service != null)
            {
                return service;
            }
            return null;
        }

        public virtual IQueryable<DomainModel.Task> GetTasks(Expression<Func<DomainModel.Task, bool>> filter = null, Func<IQueryable<DomainModel.Task>, IOrderedQueryable<DomainModel.Task>> orderBy = null, string includeProperties = "")
        {
            return unitOfWork.TasksRepository.Get(filter, orderBy, includeProperties);
        }


        public void UpdateCost(int id)
        {
            var tasks = unitOfWork.TasksRepository.Get().Where(i => i.AppointmentId == id).ToArray();
            float Cost = 0;
            foreach (DomainModel.Task task in tasks)
            {
                Cost = Cost + task.Price;
            }
            Appointment appointment = unitOfWork.AppointmentsRepository.GetByID(id);
            appointment.Cost = Cost;
            unitOfWork.AppointmentsRepository.Update(appointment);
            unitOfWork.Save();
        }

    }
}
