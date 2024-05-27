using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDo_List_AppMovil_22_1027
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void HandleTextCambio(object sender, TextChangedEventArgs args)
        {
            Console.WriteLine(args.NewTextValue);
        }

        public void HandleEnterPress(object sender, EventArgs args)
        {
            Console.WriteLine("Presione Enter");
            Label newTodo = new Label();
            newTodo.Text = InputField.Text;
            newTodo.FontSize = 20;
        }
    }
}
