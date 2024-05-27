using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo_List_AppMovil_22_1027
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
