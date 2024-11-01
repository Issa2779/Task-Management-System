using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace Task_Management_System.Network
{
    internal static class NetworkAPI
    {

        private static string getTasksEndpoint = "https://localhost:5000/api/Task/GetTasks";
        private static string addTaskEndpoint = "https://localhost:5000/api/Task/AddTask";
        private static string updateTaskEndpoint = "https://localhost:5000/api/Task/UpdateTask";

        public static async Task<string> GetTasks()
        {
            HttpClient client = new HttpClient();

            try
            {
                
                var response = await client.GetAsync(getTasksEndpoint);

                
                if (response.IsSuccessStatusCode)
                {

                    var responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody; 
                }
                else
                {
                  
                    return $"Error: {response.StatusCode}, {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network errors)
                return $"Exception: {ex.Message}";
            }
        }
        public static async Task<string> AddTask(string name,DateTime dateTime, string status)
        {

            HttpClient client = new HttpClient();
            
            var requestData = new
            {
                TaskName = name,
                DueDate = dateTime,
                
            };

            var json = JsonConvert.SerializeObject(requestData);
            
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(addTaskEndpoint, content);

                
                if (response.IsSuccessStatusCode)
                {
                    
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody; 
                }
                else
                {
                    
                    return $"Error: {response.StatusCode}, {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                
                return $"Exception: {ex.Message}";
            }
        }

        public static async Task<string> UpdateTaskAPI(int taskId, string taskName, DateTime time , string status)
        {
            HttpClient client = new HttpClient();

            //Request
            var requestData = new
            {
                Id = taskId,
                TaskName = taskName,
                DueDate = time,
                Status = status

            };

            var json = JsonConvert.SerializeObject(requestData);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                
                var response = await client.PutAsync(updateTaskEndpoint, content);

                
                if (response.IsSuccessStatusCode)
                {
                    
                    var responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody; 
                }
                else
                {
                    
                    return $"Error: {response.StatusCode}, {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
                return $"Exception: {ex.Message}";
            }
        }

        public static async Task<string> DeleteTaskAPI(int id)
        {
            HttpClient client = new HttpClient();

            try
            {
                
                var response = await client.DeleteAsync($"https://localhost:5000/api/Task/{id}/DeleteTask");

                
                if (response.IsSuccessStatusCode)
                {
                    
                    var responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody; 
                }
                else
                {
                    return $"Error: {response.StatusCode}, {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                
                return $"Exception: {ex.Message}";
            }
        }
    }
}
