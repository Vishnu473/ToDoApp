using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ToDoApp.Model;
using System.Collections.ObjectModel;

namespace ToDoApp.Views
{	
	public partial class HighPriorityTasks : ContentPage
	{	
		public HighPriorityTasks ()
		{
			InitializeComponent ();
            HighTasksList = new ObservableCollection<ToDo>();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }
        public ObservableCollection<ToDo> HighTasksList { get; set; }

        private void LoadData()
        {
            var con = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            var List = con.Table<ToDo>();
            HighTasksList.Clear();
            foreach (var item in List)
            {
                if (item.Priority.Equals("High"))
                {
                    HighTasksList.Add(item);
                }
            }
            HighTasks.ItemsSource = HighTasksList;
        }
    }
}

