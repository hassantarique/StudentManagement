
using StudentManagement.MAUI.ViewModels;

namespace StudentManagement.MAUI.Views;

public partial class IdStudentView : ContentPage
{
    private StudentViewModel viewModel;
    private int id;

    public IdStudentView(StudentViewModel viewModel, int studentId)
    {
        InitializeComponent();

        if (viewModel == null)
        {
            throw new ArgumentNullException(nameof(viewModel)); // Preventing the null reference
        }

        BindingContext = this.viewModel = viewModel;
        id = studentId;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (viewModel == null)
        {
            await DisplayAlert("Error", "ViewModel is not initialized.", "OK");
            await Navigation.PopAsync();
            return;
        }

        await viewModel.LoadStudentById(id);

        if (viewModel.SelectedStudent == null)
        {
            await DisplayAlert("Error", "No student found for the entered ID.", "OK");
            await Navigation.PopAsync();
        }
    }

}
