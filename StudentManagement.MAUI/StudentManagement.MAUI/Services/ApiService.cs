using Newtonsoft.Json;
using StudentManagement.MAUI.Models;
using System.Text;

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

        public async Task<Student?> GetStudentByIdAsync(int studentId)
        {
            try
            {
                var response = await client.GetAsync($"{baseUrl}Student/GetStudentById?StudentID={studentId}");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Student>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetStudentByIdAsync: {ex.Message}");
                return new Student { Name = "Error fetching student", ID = -1 }; // Return a meaningful error response
            }
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            try
            {
                var response = await client.GetAsync(baseUrl + "Gender/GetAllGenders");

                if (!response.IsSuccessStatusCode) return new List<Gender>();
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Gender>>(json) ?? new List<Gender>();
                {

                }
            }
            catch
            {

                return new List<Gender>();
            }
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            try
            {
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(baseUrl + "Student/InsertStudent", content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            try
            {
                if (student.ID == 0)
                {
                    return false;
                }

                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(baseUrl + "Student/UpdateStudent", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            try
            {
                var response = await client.DeleteAsync($"{baseUrl}Student/DeleteStudent?StudentID={studentId}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    }
}