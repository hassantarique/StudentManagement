using StudentManagement.MAUI.ViewModels;

namespace StudentManagement.MAUI.Views;

public partial class InsertStudentView : ContentPage
{
    private readonly GenderViewModel genderViewModel;
	public InsertStudentView()
	{
		InitializeComponent();

        genderViewModel = new GenderViewModel();
        BindingContext = genderViewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await genderViewModel.LoadGenders();
    }

    private void OnInsertStudentClicked(object sender, EventArgs e)
    {

    }

    private void OnCancelClicked(object sender, EventArgs e)
    {

    }
}