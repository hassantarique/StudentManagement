using StudentManagement.MAUI.ViewModels;

namespace StudentManagement.MAUI.Views;

public partial class StudentUpdateView : ContentPage
{
    private readonly StudentViewModel _viewModel;

    public StudentUpdateView(int studentId)
    {
        InitializeComponent();
        _viewModel = new StudentViewModel();
        BindingContext = _viewModel;

        LoadStudentAsync(studentId);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadGenders();
    }

    public async void LoadStudentAsync(int studentId)
    {
        await _viewModel.LoadStudentById(studentId);
    }

    private async void OnUpdateStudentClicked(object sender, EventArgs e)
    {
        await _viewModel.UpdateStudent();
    }
}