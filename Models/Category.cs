using SQLite;

namespace TaskApp.Database.Models
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), NotNull]
        public string Name { get; set; }
    }
}
