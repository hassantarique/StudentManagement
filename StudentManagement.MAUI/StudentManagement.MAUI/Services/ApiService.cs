using Newtonsoft.Json;
using StudentManagement.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentManagement.MAUI.Services
{
    public class ApiService
    {
        HttpClient client = new HttpClient();
        private const string baseUrl = "https://localhost:7064/api/";

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            try
            {
                var response = await client.GetAsync(baseUrl + "Student/GetAllStudents");

                if (!response.IsSuccessStatusCode) return new List<Student>();
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
            }
            catch
            {
                return new List<Student>();
            }
        }
    }
}
