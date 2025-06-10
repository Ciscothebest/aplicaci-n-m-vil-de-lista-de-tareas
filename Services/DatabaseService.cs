using SQLite;
using TaskApp.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskApp.Database.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TaskItem>().Wait();
            _database.CreateTableAsync<Category>().Wait();
        }

        // ===== TaskItem methods =====
        public Task<List<TaskItem>> GetTasksAsync() =>
            _database.Table<TaskItem>().ToListAsync();

        public Task<TaskItem> GetTaskAsync(int id) =>
            _database.Table<TaskItem>().Where(t => t.Id == id).FirstOrDefaultAsync();

        public Task<int> SaveTaskAsync(TaskItem task) =>
            task.Id != 0 ? _database.UpdateAsync(task) : _database.InsertAsync(task);

        public Task<int> DeleteTaskAsync(TaskItem task) =>
            _database.DeleteAsync(task);

        // ===== Category methods =====
        public Task<List<Category>> GetCategoriesAsync() =>
            _database.Table<Category>().ToListAsync();

        public Task<Category> GetCategoryAsync(int id) =>
            _database.Table<Category>().Where(c => c.Id == id).FirstOrDefaultAsync();

        public Task<int> SaveCategoryAsync(Category category) =>
            category.Id != 0 ? _database.UpdateAsync(category) : _database.InsertAsync(category);

        public Task<int> DeleteCategoryAsync(Category category) =>
            _database.DeleteAsync(category);
    }
}
