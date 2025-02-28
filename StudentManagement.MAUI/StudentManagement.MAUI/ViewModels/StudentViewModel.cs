using StudentManagement.MAUI.Models;
using StudentManagement.MAUI.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace StudentManagement.MAUI.ViewModels
{
    public class StudentViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public StudentViewModel()
        {
            _apiService = new ApiService();
            Students = new ObservableCollection<Student>();
            Task.Run(async () => await LoadStudents());
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        private readonly ApiService _apiService;

        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

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

        public async Task LoadStudentById(int studentId)
        {
            SelectedStudent = await _apiService.GetStudentByIdAsync(studentId);

            OnPropertyChanged();
        }

    }
}
