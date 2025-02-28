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
        public string StudentName
        {
            get => _name;
            set
            {
                _name = value; OnPropertyChanged();
                if (SelectedStudent != null)
                {
                    SelectedStudent.Name = value;
                }
            }


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
                _height = value;
                OnPropertyChanged();

                if (decimal.TryParse(value, out decimal parsedHeight))
                {
                    _heightValue = parsedHeight;
                    SelectedStudent.Height = parsedHeight;
                }
            }
        }
        private decimal _heightValue;  // Actual numeric value

        private string _weight;
        public string Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged();

                if (int.TryParse(value, out int parsedWeight))
                {
                    _weightValue = parsedWeight;
                    SelectedStudent.Weight = parsedWeight;
                }
            }
        }
        private int _weightValue;  // Actual numeric value

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();

                if (_selectedStudent != null)
                {
                    StudentName = _selectedStudent.Name;
                    SelectedGender = Genders.FirstOrDefault(g => g.GenderId == _selectedStudent.GenderID);
                    DateOfBirth = _selectedStudent.DateOfBirth;
                    Height = _selectedStudent.Height.ToString();
                    Weight = _selectedStudent.Weight.ToString();
                }
            }
        }


        public StudentViewModel()
        {
            _apiService = new ApiService();
            Students = new ObservableCollection<Student>();
            Task.Run(async () => await LoadStudents());
            UpdateStudentCommand = new Command(async () => await UpdateStudent());
        }

        private readonly ApiService _apiService;

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
            SelectedStudent = await _apiService.GetStudentByIdAsync(studentId);

            OnPropertyChanged();
        }
        public async Task InsertStudent()
        {
            if (string.IsNullOrWhiteSpace(StudentName) || SelectedGender == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill all fields.", "OK");
                return;
            }

            var student = new Student
            {
                Name = StudentName,
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
        public ICommand UpdateStudentCommand { get; }
        public async Task<bool> UpdateStudent()
        {
            if (string.IsNullOrWhiteSpace(StudentName) || SelectedGender == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill all fields.", "OK");
                return false;
            }

            var updatedStudent = new Student
            {
                ID = SelectedStudent.ID,
                Name = StudentName,
                GenderID = SelectedGender.GenderId,
                DateOfBirth = DateOfBirth,
                Height = _heightValue,
                Weight = _weightValue
            };

            var success = await _apiService.UpdateStudentAsync(updatedStudent);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Student updated successfully!", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            return success;
        }




    }
}
