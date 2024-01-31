using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoApp.Model;
using Xamarin.Forms;

namespace ToDoApp.Views
{	
	public partial class FinishedTasks : ContentPage
	{	
		public FinishedTasks ()
		{
			InitializeComponent ();
            CompletedTasksList = new ObservableCollection<ToDo>();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }
        public ObservableCollection<ToDo> CompletedTasksList { get; set; }
        private void LoadData()
        {
            var con = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            var List = con.Table<ToDo>();
            CompletedTasksList.Clear();
            foreach (var item in List)
            {
                if (DateTime.TryParse(item.CompletedDate,out DateTime date))
                {
                    CompletedTasksList.Add(item);
                }
            }
            CompletedTasks.ItemsSource = CompletedTasksList;
        }
    }
}

