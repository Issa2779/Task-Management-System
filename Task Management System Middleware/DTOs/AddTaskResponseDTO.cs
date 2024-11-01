namespace Task_Management_System_Middleware.DTOs
{
    public class AddTaskResponseDTO
    {

        public int Id { get; set; }

        public string TaskName { get; set; } = null!;

        public DateTime? DueDate { get; set; }

        public string? Status { get; set; }
    }
}
