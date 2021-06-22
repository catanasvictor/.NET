using SalonWeb.DomainModel;


namespace SalonWeb.DataAccessLayer
{
   public  interface IUnitOfWork
    {
        
        //IRepository<User> UserRepository { get;}
        IRepository<Appointment> AppointmentsRepository { get;}
        IRepository<DomainModel.Task> TasksRepository { get;}

      
        void Save();
        void Dispose();
    }
}
