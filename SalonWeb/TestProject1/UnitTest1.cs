using SalonWeb.BusinessLayer;
using SalonWeb.Data;
using SalonWeb.DomainModel;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using SalonWeb.DataAccessLayer;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySql("server=localhost;user id=root;password=root;port=3306;database=salon;",
            ServerVersion.AutoDetect("server=localhost;user id=root;password=root;port=3306;database=salon;"))
            .Options;
            Mock<ApplicationDbContext> mockDbContext = new Mock<ApplicationDbContext>(options);
            Mock<GenericRepository<Task>> mockServiceRepository = new Mock<GenericRepository<Task>>(mockDbContext.Object);
            mockServiceRepository.Setup(s => s.Delete(3));

            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.TasksRepository).Returns(mockServiceRepository.Object);
            ITaskService emp = new TaskService(mockUnitOfWork.Object);

            Task result = emp.GetTask(3);
            Assert.Null(result);
        }
    }
}
