using Microsoft.Maui.Controls;

namespace StudentManagement.MAUI.Views
{
    public partial class StudentView : ContentPage
    {
        public StudentView()
        {
            InitializeComponent();
        }

        private async void OnViewAllStudentsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllStudentsView());
        }


        private async void OnViewStudentByIdClicked(object sender, EventArgs e)
        {
            
        }

        private async void OnInsertStudentClicked(object sender, EventArgs e)
        {
            
        }

        private async void OnUpdateStudentClicked(object sender, EventArgs e)
        {
            
        }

        private async void OnDeleteStudentClicked(object sender, EventArgs e)
        {
            
        }
    }
}
