using System;
using System.Collections.Generic;
using ToDoApp.Model;
using Xamarin.Forms;

namespace ToDoApp.Views
{
    public partial class ToDoEditPage : ContentPage
    {
        public ToDoEditPage(ToDo editToDo)
        {
            InitializeComponent();
            ToDoTaskEdit = editToDo;
        }
        string[] Priority = {"Normal","Medium","High" };
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SelectPriority.ItemsSource = Priority;
            this.BindingContext = ToDoTaskEdit;
        }
        public ToDo ToDoTaskEdit { get; }

        async void SaveBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            var cn = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            cn.Update(ToDoTaskEdit);
            cn.Close();
            await Navigation.PopAsync();
        }

        async void CancelBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

