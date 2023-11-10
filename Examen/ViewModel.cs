using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    internal class ViewModel
    {
        private StatusPickerViewModel _statusPickerViewModel = new StatusPickerViewModel();
        public Tasks NewTasks { get; set; } = new Tasks();
        public StatusPickerViewModel StatusPickerViewModel
        {
            get { return _statusPickerViewModel; }
            set
            {
                if (_statusPickerViewModel != value)
                {
                    _statusPickerViewModel = value;
                    OnPropertyChanged(nameof(StatusPickerViewModel));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
