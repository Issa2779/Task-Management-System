using System.ComponentModel.DataAnnotations;

namespace Task_Management_System_Middleware.DTOs
{
    public class AddTaskRequestDTO
    {

        [Required]
        public string TaskName { get; set; } = null!;

        [Required]
        public DateTime? DueDate { get; set; }

    }
}
