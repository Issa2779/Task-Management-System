using Task_Management_System_Middleware.Models;

namespace Task_Management_System_Middleware.SQLRepository.TaskRepository
{
    public interface ITaskRepository
    {


        Task<UserTask> AddTask(UserTask data);

        Task<List<UserTask>> GetTasks();
        

        Task<string> UpdateTask(UserTask data);

        Task<string> DeleteTask(int id);

    }
}
