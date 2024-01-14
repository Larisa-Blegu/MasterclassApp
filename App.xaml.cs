using System;
using System.IO;
using MasterclassApp.Data;

namespace MasterclassApp
{
    public partial class App : Application
    {
        static CursDatabase database;

        public static CursDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CursDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Curs.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
