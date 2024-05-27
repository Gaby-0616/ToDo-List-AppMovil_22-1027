using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDo_List_AppMovil_22_1027
{
    public class TodoDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public TodoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ToDoItem>().Wait();
        }

        public Task<List<ToDoItem>> GetToDoItemsAsync()
        {
            return _database.Table<ToDoItem>().ToListAsync();
        }

        public Task<int> SaveToDoItemAsync(ToDoItem item)
        {
            if (item.Id != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteToDoItemAsync(ToDoItem item)
        {
            return _database.DeleteAsync(item);
        }
    }
}