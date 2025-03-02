using Microsoft.Maui.Controls;
using StudentManagement.MAUI.ViewModels;

namespace StudentManagement.MAUI.Views
{
    public partial class StudentView : ContentPage
    {
        private StudentViewModel _viewModel;

        public StudentView()
        {
            InitializeComponent();
            _viewModel = new StudentViewModel();
            BindingContext = _viewModel;
        }

        private async void OnViewAllStudentsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllStudentsView());
        }


        private async void OnViewStudentByIdClicked(object sender, EventArgs e)
        {
            if (int.TryParse(StudentIdEntry.Text, out int studentId))
            {
                var viewModel = BindingContext as StudentViewModel;
                if (viewModel != null)
                {
                    await viewModel.LoadStudentById(studentId);
                    await Navigation.PushAsync(new IdStudentView(viewModel, studentId));
                }
                else
                {
                    await DisplayAlert("Error", "ViewModel is null!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please enter a valid Student ID", "OK");
            }
        }


        private async void OnInsertStudentClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertStudentView());
        }

        private async void OnUpdateStudentClicked(object sender, EventArgs e)
        {
            if (int.TryParse(StudentIdEntryTwo.Text, out int studentId))
            {
                await Navigation.PushAsync(new StudentUpdateView(studentId));
            }
            else
            {
                await DisplayAlert("Error", "Please enter a valid Student ID.", "OK");
            }
        }

        private async void OnDeleteStudentClicked(object sender, EventArgs e)
        {
            if (int.TryParse(DeleteStudentIdEntry.Text, out int studentId) && studentId > 0)
            {
                bool isDeleted = await _viewModel.DeleteStudentAsync(studentId);
                if (isDeleted)
                {
                    await DisplayAlert("Success", "Student deleted successfully!", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Failed to delete student. Please try again.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Invalid Input", "Please enter a valid Student ID.", "OK");
            }
        }
    }
}
