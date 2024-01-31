using System;
using System.Collections.Generic;
using ToDoApp.Model;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ToDoApp.Views
{	
	public partial class ManageToDoView : ContentPage
	{	
		public ManageToDoView ()
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
            ToDoList.Clear();
            var con = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            ToDoTable = con.Table<ToDo>();
            foreach (var item in ToDoTable)
            {
                ToDoList.Add(item);
            }
            if (ToDoTable.ToList().Count == 0)
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

        async void MIDelete_Clicked(System.Object sender, System.EventArgs e)
        {
            var cn = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            var menuItem = sender as MenuItem;
            var deleteRecord = menuItem.CommandParameter as ToDo;
            string msg = deleteRecord.TaskTitle + "\nPriority: " + deleteRecord.Priority;
            cn.Delete(deleteRecord);
            cn.Close();
            LoadToDoData();
            await DisplayAlert("Task Deleted Successfully", msg, "OK");
        }
    }
}

