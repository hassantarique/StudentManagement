using StudentManagement.MAUI.Models;
using StudentManagement.MAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.MAUI.ViewModels
{
    public class GenderViewModel : BaseViewModel, INotifyPropertyChanged
    {
        ApiService _apiService = new ApiService();

        private Gender _selectedGender;
        public Gender SelectedGender
        {
            get => _selectedGender;
            set
            {
                _selectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }

        public ObservableCollection<Gender> Genders { get; set; } = new ObservableCollection<Gender>();

        public async Task LoadGenders()
        {
            var genders = await _apiService.GetGenders();
            Genders.Clear();
            foreach (Gender gender in genders)
            {
                Genders.Add(gender);
            }
        }
    }
}
