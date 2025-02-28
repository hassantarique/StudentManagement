using StudentManagement.MAUI.ViewModels;

namespace StudentManagement.MAUI.Views
{
    public partial class StudentUpdateView : ContentPage
    {
        private readonly StudentViewModel _viewModel;

        public StudentUpdateView(StudentViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;

            LoadStudentData();
        }

        private async void LoadStudentData()
        {
            await _viewModel.LoadGenders();
        }

        private async void OnUpdateStudentClicked(object sender, EventArgs e)
        {
            bool isUpdated = await _viewModel.UpdateStudent();
            if (isUpdated)
            {
                await DisplayAlert("Success", "Student details updated successfully!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to update student.", "OK");
            }
        }
    }
}
