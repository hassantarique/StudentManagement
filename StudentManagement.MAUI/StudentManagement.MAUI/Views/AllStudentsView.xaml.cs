using StudentManagement.MAUI.ViewModels;

namespace StudentManagement.MAUI.Views
{
    public partial class AllStudentsView : ContentPage
    {
        public AllStudentsView()
        {
            InitializeComponent();
            BindingContext = new StudentViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is StudentViewModel viewModel)
            {
                await viewModel.LoadStudents();
            }
        }

    }
}
