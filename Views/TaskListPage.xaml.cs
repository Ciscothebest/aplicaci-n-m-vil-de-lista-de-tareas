using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaskApp.Models;
using System;

namespace TaskApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListPage : ContentPage
    {
        public TaskListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            taskList.ItemsSource = await App.Database.GetTasksAsync();
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskDetailPage());
        }

        private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count != 0)
            {
                var selectedTask = (TaskItem)e.CurrentSelection[0];
                await Navigation.PushAsync(new TaskDetailPage(selectedTask));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
