using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaskApp.Models;
using System;

namespace TaskApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskDetailPage : ContentPage
    {
        TaskItem currentTask;

        public TaskDetailPage(TaskItem task = null)
        {
            InitializeComponent();
            currentTask = task ?? new TaskItem();
            BindingContext = currentTask;

            nameEntry.Text = currentTask.Name;
            descriptionEditor.Text = currentTask.Description;
            deleteButton.IsVisible = task != null;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            currentTask.Name = nameEntry.Text;
            currentTask.Description = descriptionEditor.Text;

            if (string.IsNullOrWhiteSpace(currentTask.Name))
            {
                await DisplayAlert("Error", "El nombre es obligatorio.", "OK");
                return;
            }

            try
            {
                await App.Database.SaveTaskAsync(currentTask);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo guardar: {ex.Message}", "OK");
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmar", "¿Eliminar esta tarea?", "Sí", "No"))
            {
                await App.Database.DeleteTaskAsync(currentTask);
                await Navigation.PopAsync();
            }
        }
    }
}
