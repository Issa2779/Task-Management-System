using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    internal class TaskListData
    {

        public int Id { get; set; }

        public string TaskName { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
