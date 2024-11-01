using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System_Middleware.DTOs;
using Task_Management_System_Middleware.Models;
using Task_Management_System_Middleware.SQLRepository.TaskRepository;

namespace Task_Management_System_Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {


        private readonly ITaskRepository taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        [HttpPost]
        [Route("AddTask")]
        public async Task<IActionResult> AddTask(AddTaskRequestDTO data)
        {

            if (data == null)
            {

                return BadRequest();

            }
            else
            {

                var request = new UserTask
                {

                    TaskName = data.TaskName,
                    DueDate = data.DueDate,
                    
                };

                var dataResponse = await taskRepository.AddTask(request);

                return Ok(dataResponse);
            }


        }

        [HttpGet]
        [Route("GetTasks")]
        public async Task<IActionResult> GetAllTasks()
        {


            var dataContect = await taskRepository.GetTasks();

            var tasksDTO = new List<GetTasksDTO>();

            if (dataContect != null)
            {
                foreach (var item in dataContect)
                {
                    tasksDTO.Add(new GetTasksDTO
                    {
                        Id = item.Id,
                        TaskName = item.TaskName,
                        DueDate = item.DueDate,
                        Status = item.Status

                    });
                }
                return Ok(tasksDTO);
            }
            else
                return NoContent();

            
        }


        [HttpPut]
        [Route("UpdateTask")]
        public async Task<IActionResult> UpdateTask(UpdateTaskRequestDTO data)
        {
            try
            {

                if (data != null)
                {

                    var dataDB = new UserTask
                    {

                        Id = data.Id,
                        TaskName = data.TaskName,
                        DueDate = data.DueDate,
                        Status = data.Status,

                    };

                    string response = await taskRepository.UpdateTask(dataDB);


                    return Ok();

                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}/DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {

            string response = await taskRepository.DeleteTask(id);

            if(response == "200")
            {
                return Ok();
            }
            else
                return BadRequest();
        }

    }
}
