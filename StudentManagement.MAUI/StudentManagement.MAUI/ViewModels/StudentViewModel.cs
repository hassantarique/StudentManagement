using StudentManagement.MAUI.Models;
using StudentManagement.MAUI.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace StudentManagement.MAUI.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public StudentViewModel()
        {
            _apiService = new ApiService();
            Students = new ObservableCollection<Student>();
            Task.Run(async () => await LoadStudents());
        }


        public async Task LoadStudents()
        {
            var studentList = await _apiService.GetAllStudentsAsync();
            if (studentList != null)
            {
                Students.Clear();
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
            }
        }
    }
}
