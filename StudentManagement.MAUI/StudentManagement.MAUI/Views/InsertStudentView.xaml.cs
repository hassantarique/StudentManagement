using StudentManagement.MAUI.ViewModels;

namespace StudentManagement.MAUI.Views;

public partial class InsertStudentView : ContentPage
{
    private readonly StudentViewModel _studentViewModel;

    public InsertStudentView()
    {
        InitializeComponent();
        _studentViewModel = new StudentViewModel();
        BindingContext = _studentViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _studentViewModel.LoadGenders();
    }

    private async void OnInsertStudentClicked(object sender, EventArgs e)
    {
        await _studentViewModel.InsertStudent();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}