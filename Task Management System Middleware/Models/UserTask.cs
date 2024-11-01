using System;
using System.Collections.Generic;

namespace Task_Management_System_Middleware.Models;

public partial class UserTask
{
    public int Id { get; set; }

    public string TaskName { get; set; } = null!;

    public DateTime? DueDate { get; set; }

    public string? Status { get; set; }
}
