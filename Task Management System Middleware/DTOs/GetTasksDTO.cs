using System.ComponentModel.DataAnnotations;

namespace Task_Management_System_Middleware.DTOs
{
    public class GetTasksDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string TaskName { get; set; } = null!;

        [Required]
        public DateTime? DueDate { get; set; }

        [Required]
        public string? Status { get; set; }
    }
}
