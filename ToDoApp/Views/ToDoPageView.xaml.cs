using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Model;
using Xamarin.Forms;

namespace ToDoApp.Views
{	
	public partial class ToDoPageView : ContentPage
	{	
		public ToDoPageView ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadToDoData();
        }

        public SQLite.TableQuery<ToDo> ToDoTable { get; set; }

        private void LoadToDoData()
        {
            var con = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            //con.DeleteAll<ToDo>();
            var TableColumns = con.GetTableInfo("ToDo");
            if (TableColumns == null)
            {
                con.CreateTable<ToDo>();
                
            }
            ToDoTable = con.Table<ToDo>();
            ToDoCollection.ItemsSource = ToDoTable;
            if (ToDoTable.Count() == 0)
            {
                Message.Text = "No Tasks Added.\nAdd Tasks to display";
                Message.IsVisible = true;
                Message.TextColor = Color.DarkGray;
            }
            else
            {
                Message.IsVisible = false;
            }
        }

        async void AddToDo_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ToDoMainView());
        }

        async void Nots_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new HighPriorityTasks());
        }

        async void CompletedTasks_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FinishedTasks());
        }

        async void FeedBack_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FeedbackView());
        }

        async void ViewAllTasks_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ViewAllTasks());
        }

        async void ManageTasks_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ManageToDoView());
        }

        async void ToDoCollection_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var task = e.Item as ToDo;
            await Navigation.PushAsync(new TaskDetailPage(task.TaskTitle, task.TaskDescription, task.Priority, task.CreatedDate, task.CompletedDate));
        }

        async void About_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AboutUsView());
        }
    }

}

