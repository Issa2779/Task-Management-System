﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Management_System
{
    internal static class MethodHelper
    {


        public static string StatusHandling(DateTime time, string status)
        {
            DateTime currentTime = DateTime.Now;


            if (currentTime.Date <= time && status != "Completed")
            {

                return "Pending";

            }
            else if (currentTime.Date > time && status != "Completed")
            {
                return "Overdue";

            }

            return status;
        }

        public static void ColorChange(DataGridView dataTasksView)
        {
            foreach (DataGridViewRow row in dataTasksView.Rows)
            {
                string checkStatus = Convert.ToString(row.Cells[3].Value);

                switch (checkStatus)
                {
                    case "Overdue": row.Cells[3].Style.BackColor = Color.Red; break;
                    case "Completed": row.Cells[3].Style.BackColor = Color.Green; break;
                    case "Pending": row.Cells[3].Style.BackColor = Color.White; break;
                }
            }
        }


    }
}
