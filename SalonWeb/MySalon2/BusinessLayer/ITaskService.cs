using System;
using System.Linq;
using System.Linq.Expressions;


namespace SalonWeb.BusinessLayer
{
    public interface ITaskService
    {
        void AddTask(DomainModel.Task task);
        void UpdateTask(DomainModel.Task task);
        void DeleteTask(int id);
        void DeleteTaask(DomainModel.Task task);
        DomainModel.Task GetTask(int id);
        IQueryable<DomainModel.Task> GetTasks(Expression<Func<DomainModel.Task, bool>> filter = null, Func<IQueryable<DomainModel.Task>, IOrderedQueryable<DomainModel.Task>> orderBy = null, string includeProperties = "");
    }
}
