using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        public static void CalculateThreading(DataGridView dataTasksView, int timer,string testThread,Label label)
        {

            try
            {
                int result = 0;

                foreach (DataGridViewRow row in dataTasksView.Rows)
                {

                    result = (int)row.Cells["Priority"].Value * -1;

                    row.Cells["Priority"].Value = result;

                    if (result < 0)
                    {
                        row.Cells[5].Style.BackColor = Color.Red;
                    }
                    else if (result > 0)
                    {
                        row.Cells[5].Style.BackColor = Color.Green;
                    }

                    //I fixed the cross thread issue by changing the text in the main thread since the UI runs on the main thread
                    label.Invoke((MethodInvoker)(() => label.Text = testThread));
                  
                    Thread.Sleep(timer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thread Error: " + ex);
            }
        }
    }
}
