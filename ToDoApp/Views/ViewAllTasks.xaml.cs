using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoApp.Model;
using Xamarin.Forms;

namespace ToDoApp.Views
{	
	public partial class ViewAllTasks : ContentPage
	{	
		public ViewAllTasks ()
		{
			InitializeComponent ();
            ToDoList = new ObservableCollection<ToDo>();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadToDoData();
        }

        public SQLite.TableQuery<ToDo> ToDoTable { get; set; }
        public ObservableCollection<ToDo> ToDoList { get; set; }

        private async void LoadToDoData()
        {
            var con = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            ToDoTable = con.Table<ToDo>();
            ToDoList.Clear();
            foreach (var item in ToDoTable)
            {
                ToDoList.Add(item);
            }
            if (ToDoList.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Message", "No Tasks to display", "OK");
            }
            ToDoCollection.ItemsSource = ToDoList;
        }
        async void MIEdit_Clicked(System.Object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var EditRecord = menuItem.CommandParameter as ToDo;
            await Navigation.PushAsync(new ToDoEditPage(EditRecord));
        }

        void MIDelete_Clicked(System.Object sender, System.EventArgs e)
        {
            var cn = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            var menuItem = sender as MenuItem;
            var deleteRecord = menuItem.CommandParameter as ToDo;
            cn.Delete(deleteRecord);
            cn.Close();
            LoadToDoData();
        }
    }
}

