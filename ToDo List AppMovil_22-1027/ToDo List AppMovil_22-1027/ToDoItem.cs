using SQLite;
using System.ComponentModel;

namespace ToDo_List_AppMovil_22_1027
{
    public class ToDoItem : INotifyPropertyChanged
    {
        private int id;
        private string todoText;
        private bool completo;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string TodoText
        {
            get => todoText;
            set
            {
                if (todoText != value)
                {
                    todoText = value;
                    OnPropertyChanged(nameof(TodoText));
                }
            }
        }

        public bool Completo
        {
            get => completo;
            set
            {
                if (completo != value)
                {
                    completo = value;
                    OnPropertyChanged(nameof(Completo));
                }
            }
        }

        // Constructor sin parámetros requerido por SQLite
        public ToDoItem() { }

        // Constructor con parámetros para conveniencia
        public ToDoItem(string todoText, bool completo)
        {
            TodoText = todoText;
            Completo = completo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}