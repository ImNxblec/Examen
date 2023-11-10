using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Examen
{
    public partial class MainPage : ContentPage , INotifyPropertyChanged
    {
        public ObservableCollection<Tasks> Tareas { get; set; } = new ObservableCollection<Tasks>();

        public MainPage()
        {
            InitializeComponent();
            CreateOneTask();

            MessagingCenter.Subscribe<AgregarTareas, Tasks>(this, "AgregarTarea", (sender, tarea) =>
            {
                Tareas.Add(tarea);
            });
            BindingContext = this;
        }

        private void CreateOneTask()
        {
            var MiTarea = new Tasks()
            {};
            Tareas.Add(MiTarea);
        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarTareas());
        }
    }
}