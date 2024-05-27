using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ToDo_List_AppMovil_22_1027
{
    public class TodoListViewModel : BindableObject
    {
        private string newTodoInputValue;
        private TodoDatabase database;

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }

        public TodoListViewModel()
        {
            ToDoItems = new ObservableCollection<ToDoItem>();
            database = new TodoDatabase(DependencyService.Get<IDatabasePath>().GetDatabasePath());
            LoadToDoItems();
        }

        public string NewTodoInputValue
        {
            get => newTodoInputValue;
            set
            {
                newTodoInputValue = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddTodoCommand => new Command(async () => await AddTodoItem());

        private async Task AddTodoItem()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoInputValue))
            {
                var newItem = new ToDoItem(NewTodoInputValue, false);
                await database.SaveToDoItemAsync(newItem);
                ToDoItems.Add(newItem);
                NewTodoInputValue = string.Empty; 
            }
        }

        public ICommand RemoveTodoCommand => new Command<ToDoItem>(async (item) => await RemoveTodoItem(item));

        private async Task RemoveTodoItem(ToDoItem item)
        {
            await database.DeleteToDoItemAsync(item);
            ToDoItems.Remove(item);
        }

        private async void LoadToDoItems()
        {
            var items = await database.GetToDoItemsAsync();
            foreach (var item in items)
            {
                ToDoItems.Add(item);
            }
        }

        public ICommand EditTodoCommand => new Command<ToDoItem>(async (item) => await EditTodoItem(item));
        async System.Threading.Tasks.Task EditTodoItem(ToDoItem todoItem)
        {
            string result = await Application.Current.MainPage.DisplayPromptAsync("Edit ToDo", "Modify your todo:", initialValue: todoItem.TodoText);
            if (!string.IsNullOrWhiteSpace(result))
            {
                todoItem.TodoText = result;
                OnPropertyChanged(nameof(ToDoItems));
            }
        }

    }
}
