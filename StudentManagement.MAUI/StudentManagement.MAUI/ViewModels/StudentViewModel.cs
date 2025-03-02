using StudentManagement.MAUI.Models;
using StudentManagement.MAUI.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Xml.Linq;

namespace StudentManagement.MAUI.ViewModels
{
    public class StudentViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private Gender _selectedGender;
        public Gender SelectedGender
        {
            get => _selectedGender;
            set { _selectedGender = value; OnPropertyChanged(); }
        }

        private DateTime _dateOfBirth = DateTime.Today;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set { _dateOfBirth = value; OnPropertyChanged(); }
        }

        private string _height;
        public string Height
        {
            get => _height;
            set
            {
                if (decimal.TryParse(value, out decimal parsedHeight))
                {
                    _height = value;
                    _heightValue = parsedHeight;  // Store actual decimal value
                }
                else
                {
                    _height = string.Empty;  // Reset if invalid input
                }
                OnPropertyChanged();
            }
        }
        private decimal _heightValue;  // Actual numeric value

        private string _weight;
        public string Weight
        {
            get => _weight;
            set
            {
                if (int.TryParse(value, out int parsedWeight))
                {
                    _weight = value;
                    _weightValue = parsedWeight;  // Store actual int value
                }
                else
                {
                    _weight = string.Empty;  // Reset if invalid input
                }
                OnPropertyChanged();
            }
        }
        private int _weightValue;  // Actual numeric value

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    OnPropertyChanged(nameof(StudentId)); // Notify UI
                }
            }
        }

        private int _studentId;
        public int StudentId
        {
            get => _studentId;
            set { _studentId = value; OnPropertyChanged(); }
        }


        private readonly ApiService _apiService;

        public StudentViewModel()
        {
            _apiService = new ApiService();
            Students = new ObservableCollection<Student>();
            Task.Run(async () => await LoadStudents());
        }

        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public ObservableCollection<Gender> Genders { get; set; } = new ObservableCollection<Gender>();

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
        public async Task LoadGenders()
        {
            var genders = await _apiService.GetGenders();
            Genders.Clear();
            foreach (Gender gender in genders)
            {
                Genders.Add(gender);
            }
        }
        public async Task LoadStudentById(int studentId)
        {
            var student = await _apiService.GetStudentByIdAsync(studentId);
            if (student != null)
            {
                StudentId = student.ID; // Store ID 
                Name = student.Name;
                SelectedGender = Genders.FirstOrDefault(g => g.GenderId == student.GenderID);
                DateOfBirth = student.DateOfBirth;
                Height = student.Height.ToString();
                Weight = student.Weight.ToString();
            }
            OnPropertyChanged(nameof(StudentId)); // Ensure UI update
        }
        public async Task InsertStudent()
        {
            if (string.IsNullOrWhiteSpace(Name) || SelectedGender == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill all fields.", "OK");
                return;
            }

            var student = new Student
            {
                Name = Name,
                GenderID = SelectedGender.GenderId,
                DateOfBirth = DateOfBirth,
                Height = _heightValue,
                Weight = _weightValue
            };

            var success = await _apiService.AddStudentAsync(student);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Student added successfully!", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to add student.", "OK");
            }
        }

        public async Task UpdateStudent()
        {
            if (string.IsNullOrWhiteSpace(Name) || SelectedGender == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill all fields.", "OK");
                return;
            }

            var student = new Student
            {
                ID = StudentId, // Include ID for update
                Name = Name,
                GenderID = SelectedGender.GenderId,
                DateOfBirth = DateOfBirth,
                Height = _heightValue,
                Weight = _weightValue
            };

            var success = await _apiService.UpdateStudentAsync(student);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Student updated successfully!", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to update student.", "OK");
            }
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            return await _apiService.DeleteStudentAsync(studentId);
        }

    }
}