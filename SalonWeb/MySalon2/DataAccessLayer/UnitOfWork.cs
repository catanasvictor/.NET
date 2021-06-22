using SalonWeb.Data;
using SalonWeb.DomainModel;
using System;


namespace SalonWeb.DataAccessLayer
{

    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private ApplicationDbContext _context;
     
        private bool disposed = false;

        private IRepository<User> userRepository { get ; set ; }
        private IRepository<Appointment> appointmentRepository { get; set; }
        private IRepository<DomainModel.Task> taskRepository { get; set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public IRepository<User> UsersRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(_context);
                }
                return userRepository;
            }
        }


       public IRepository<Appointment> AppointmentsRepository
        {
            get
            {

                if (this.appointmentRepository == null)
                {
                    this.appointmentRepository = new GenericRepository<Appointment>(_context);
                }
                return appointmentRepository;
            }
        }

        public IRepository<DomainModel.Task> TasksRepository
        {
            get
            {

                if (this.taskRepository == null)
                {
                    this.taskRepository = new GenericRepository<DomainModel.Task>(_context);
                }
                return taskRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
