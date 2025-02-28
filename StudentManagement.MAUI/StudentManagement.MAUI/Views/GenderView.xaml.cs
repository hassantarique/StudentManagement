using StudentManagement.MAUI.ViewModels;

namespace StudentManagement.MAUI.Views;

public partial class GenderView : ContentPage
{
    private readonly GenderViewModel genderViewModel;
    public GenderView()
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
}
