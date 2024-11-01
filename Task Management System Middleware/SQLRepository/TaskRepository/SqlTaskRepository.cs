using Microsoft.EntityFrameworkCore;
using Task_Management_System_Middleware.Context;
using Task_Management_System_Middleware.DTOs;
using Task_Management_System_Middleware.Models;

namespace Task_Management_System_Middleware.SQLRepository.TaskRepository
{
    public class SqlTaskRepository : ITaskRepository
    {

        private string pendingStatus = "Pending";
        private string overdueStatus = "Overdue";

        private readonly TaskManagementSystemDbContext dbContext;
        public SqlTaskRepository(TaskManagementSystemDbContext dbContext)
        {

            this.dbContext = dbContext;

        }
        public async Task<UserTask> AddTask(UserTask data)
        {

            try
            {

                DateTime currentTime = DateTime.Now;

                data.Status = currentTime.Date <= data.DueDate ? pendingStatus : overdueStatus;
                

                await dbContext.AddAsync(data);
                await dbContext.SaveChangesAsync();

                var newData = await dbContext.UserTasks.OrderByDescending(t => t.Id).FirstAsync();

                return newData; 
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<List<UserTask>> GetTasks()
        {

            var data = await dbContext.UserTasks.ToListAsync();

            
            return data;


        }
        public async Task<string> UpdateTask(UserTask data)
        {
            try
            {
                var dataContext = await dbContext.UserTasks.FindAsync(data.Id);

                if (dataContext != null)
                {
                    dataContext.TaskName = data.TaskName;
                    dataContext.DueDate = data.DueDate;
                    dataContext.Status = data.Status;
                    
                    await dbContext.SaveChangesAsync();

                    return "200";
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }


        public async Task<string> DeleteTask(int taskId)
        {

            try
            {
                var dataDelete = await dbContext.UserTasks.FindAsync(taskId);


                if(dataDelete != null)
                {
                    dbContext.UserTasks.Remove(dataDelete);

                    await dbContext.SaveChangesAsync();

                    return "200";
                }

                return "Not Found";
            }
            catch (Exception ex) { 

                return ex.Message;
            }
        }

    }
}
