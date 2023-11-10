using System.ComponentModel;

namespace Examen;

public partial class AgregarTareas : ContentPage , INotifyPropertyChanged
{
    private ViewModel _viewModel = new ViewModel();

    public AgregarTareas()
    {
        InitializeComponent();
        BindingContext = _viewModel;
    }

    private void ConfirmarBtn_Clicked(object sender, EventArgs e)
    {
        string taskName = _viewModel.NewTasks.TaskName;
        string status = _viewModel.StatusPickerViewModel.SelectedStatus;

        if (string.IsNullOrWhiteSpace(taskName))
        {
            DisplayAlert("Error", "El nombre de la tarea no puede estar vacío", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(status))
        {
            DisplayAlert("Error", "Por favor, selecciona un estado", "OK");
            return;
        }
        MessagingCenter.Send(this, "AgregarTarea", new Tasks
        {
            TaskName = taskName,
            Status = status
        });

        Navigation.PopAsync();
    }
}