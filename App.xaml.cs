using Xamarin.Forms;
using System.IO;

namespace TaskApp
{
    public partial class App : Application
    {
        static DatabaseService database;

        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tasks.db3");
                    database = new DatabaseService(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.TaskListPage());
        }
    }
}
