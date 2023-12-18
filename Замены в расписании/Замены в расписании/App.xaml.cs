using Microsoft.UI.Xaml;
using System.IO;
using Microsoft.Data.Sqlite;
namespace Замены_в_расписании
{
    public partial class App : Application
    {
        public static Data.Model model = new Data.Model();
        public App()
        {
            this.InitializeComponent();
            if (File.Exists("C:\\Изменения в расписании\\DataBase.db") == false)
            {
                File.Create("C:\\Изменения в расписании\\DataBase.db").Close();
                SqliteConnection sqliteConnection = new SqliteConnection("Data Source = C:\\Изменения в расписании\\DataBase.db");
                sqliteConnection.Open();
                SqliteCommand command = sqliteConnection.CreateCommand();
                command.Connection = sqliteConnection;
                command.CommandText = "CREATE TABLE Специалиности_и_профессии (ID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, Специальность_профессия TEXT); CREATE TABLE Группы (ID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, Название_группы TEXT, Специальность_профессия INTEGER REFERENCES Специалиности_и_профессии (ID)); CREATE TABLE Дисциплины (ID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, Название_дисциплины TEXT, Специальность_профессия INTEGER REFERENCES Специалиности_и_профессии (ID));";
                command.ExecuteNonQuery();
                sqliteConnection.Close();
            }
            if (File.Exists("C:\\Изменения в расписании\\Все замены.pdf") == false)
            {
                File.Create("C:\\Изменения в расписании\\Все замены.pdf");
            }
        }
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new Windows.Замены_в_расписании();
            m_window.Activate();
        }
        private Window m_window;
    }
}
