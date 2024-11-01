using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_Management_System.Network;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Task_Management_System
{
    public partial class MainPage : Form
    {

        private List<TaskListData> dataObjects = new List<TaskListData>();
        private DataTable dataTable = new DataTable();
        private TaskListData taskListData = new TaskListData();

        public MainPage()
        {
            InitializeComponent();

            LoadTasksData();
        }

        private async void LoadTasksData()
        {

            try
            {
                string responseBody = await NetworkAPI.GetTasks();

                dataObjects = JsonConvert.DeserializeObject<List<TaskListData>>(responseBody);


                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("Task Name", typeof(string));
                dataTable.Columns.Add("Due Date", typeof(DateTime));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Change Status", typeof(bool));


                foreach (var task in dataObjects)
                {

                    //Handling new updated time when loading data V1.1

                    task.Status = MethodHelper.StatusHandling((DateTime)task.DueDate,task.Status);

                    //Update API Invoked
                    string response = await NetworkAPI.UpdateTaskAPI(task.Id, task.TaskName, (DateTime)task.DueDate, task.Status);

                    bool check = true;

                    //CheckBox Validation
                    check = (task.Status == "Pending" || task.Status == "Overdue")? false : true;
                    
                    dataTable.Rows.Add(task.Id, task.TaskName, task.DueDate, task.Status, check);

                }

                //insert data to the Grid
                dataTasksView.DataSource = dataTable;

                //Disable changes inside the grid
                dataTasksView.Columns["ID"].ReadOnly = true;
                dataTasksView.Columns["Task Name"].ReadOnly = true;
                dataTasksView.Columns["Due Date"].ReadOnly = true;
                dataTasksView.Columns["Status"].ReadOnly = true;

                //Color Chnage depending on the Status
                MethodHelper.ColorChange(dataTasksView);

                //Disabling Columns sorting for event listener for the data grid select view
                foreach (DataGridViewColumn column in dataTasksView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex);

            }

        }

        //Event for dynamic check box to update the status from the data grid (Cell Value change)
        private async void dataTasksView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dataTasksView.Columns[e.ColumnIndex].Name == "Change Status")
                {

                    DateTime currentTime = DateTime.Now;

                    int rowIndex = e.RowIndex;
                    bool isChecked = Convert.ToBoolean(dataTasksView.Rows[rowIndex].Cells["Change Status"].Value);
                    int taskId = Convert.ToInt32(dataTasksView.Rows[rowIndex].Cells["ID"].Value);
                    string taskName = Convert.ToString(dataTasksView.Rows[rowIndex].Cells["Task Name"].Value);
                    DateTime time = Convert.ToDateTime(dataTasksView.Rows[rowIndex].Cells["Due Date"].Value);

                    string newStatus = "";

                    if (isChecked == true)
                    {
                        newStatus = "Completed";

                    }
                    else if (currentTime.Date <= time.Date)
                    {
                        newStatus = "Pending";
                    }
                    else
                    {
                        newStatus = "Overdue";
                    }

                    //Update Database API Request
                    string responseCode = await NetworkAPI.UpdateTaskAPI(taskId, taskName, time, newStatus);

                    // Update the status in the DataGridView
                    dataTasksView.Rows[rowIndex].Cells["Status"].Value = newStatus;

                    MethodHelper.ColorChange(dataTasksView);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Connection Error: " + ex);
            }
        }

        //Event to reflect changes to update text boxes when a row is selected
        private void dataTasksView_SelectionChanged(object sender, EventArgs e)
        {

            int selectedRow = dataTasksView.CurrentCell.RowIndex;

            try
            {
                int id = Convert.ToInt32(dataTasksView.Rows[selectedRow].Cells["ID"].Value);

                string taskName = Convert.ToString(dataTasksView.Rows[selectedRow].Cells["Task Name"].Value);
                DateTime time = Convert.ToDateTime(dataTasksView.Rows[selectedRow].Cells["Due Date"].Value);

                //TextBox reflection
                idUpdateBox.Text = id.ToString();
                taskNameBoxUpdate.Text = taskName;
                dateTimePickerUpdate.Value = time;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        //Add Task Function
        private async void AddTask_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime time = dateTimePicker.Value;

                //Validation
                if (taskBox.Text == string.Empty || dateTimePicker.Value == null)
                {
                    MessageBox.Show("Please Fill The Task Name to add it");
                }
                else
                {
                    string newData = await NetworkAPI.AddTask(taskBox.Text, time, "");


                    taskListData = JsonConvert.DeserializeObject<TaskListData>(newData);

                    //Add new task to the view
                    dataTable.Rows.Add(taskListData.Id, taskListData.TaskName, taskListData.DueDate, taskListData.Status);

                    
                    MethodHelper.ColorChange(dataTasksView);               
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Connection Error!");
            }


        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //To avoid Index Row Null Exceptionm on the last item to be deleted  Disabled the event listener
                dataTasksView.SelectionChanged -= dataTasksView_SelectionChanged;

                int selectedRow = dataTasksView.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataTasksView.Rows[selectedRow].Cells["ID"].Value); //To reserve the id

                dataTasksView.Rows.RemoveAt(selectedRow);

                string response = await NetworkAPI.DeleteTaskAPI(id);

                dataTasksView.SelectionChanged += dataTasksView_SelectionChanged;
            }
            catch(Exception ex)
            {
                dataTasksView.SelectionChanged += dataTasksView_SelectionChanged;
                MessageBox.Show("No Data to be deleted!");
            }
           

        }

        private async void EditButtonData_Click(object sender, EventArgs e)
        {
            
            int selectedRowIndex = dataTasksView.CurrentCell.RowIndex;

            int id = Convert.ToInt32(idUpdateBox.Text);
            string taskName = taskNameBoxUpdate.Text;

            //Automatically selected
            string status = Convert.ToString(dataTasksView.Rows[selectedRowIndex].Cells["Status"].Value);

            DateTime time = Convert.ToDateTime(dateTimePickerUpdate.Value);

            try
            {
                // Handle validation for the status when updating the time V1.2
                
                status = MethodHelper.StatusHandling(time, status);
                
                //API Update Invoke
                string response = await NetworkAPI.UpdateTaskAPI(id, taskName, time ,status);

                dataTasksView.Rows[selectedRowIndex].Cells["Task Name"].Value = taskName;
                dataTasksView.Rows[selectedRowIndex].Cells["Due Date"].Value = time.ToString();

                dataTasksView.Rows[selectedRowIndex].Cells["Status"].Value = status;

                MethodHelper.ColorChange(dataTasksView);

            }
            catch(Exception ex)
            {
                MessageBox.Show("An Error in the request has occured\n\n" + ex);
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            //Disabling event when filtering for index row selection Null Exception
            dataTasksView.SelectionChanged -= dataTasksView_SelectionChanged;
            
            DataView dataView = dataTable.DefaultView;

            dataView.RowFilter = $"[Task Name] LIKE '%{SearchTextBox.Text}%'";

            dataTasksView.DataSource = dataView;

            MethodHelper.ColorChange(dataTasksView);

            //Enabling
            dataTasksView.SelectionChanged += dataTasksView_SelectionChanged;

        }
    }
}