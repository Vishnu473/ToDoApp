using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Model;
using Xamarin.Forms;

namespace ToDoApp.Views
{	
	public partial class ToDoMainView : ContentPage
	{	
		public ToDoMainView ()
		{
			InitializeComponent ();
		}
        string[] Priority = { "Normal", "Medium", "High" };

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var con = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            int LastInsertedIndex =  con.Table<ToDo>().Count();
            SelectPriority.ItemsSource = Priority;
            PickDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            SelectPriority.SelectedItem = con.Table<ToDo>().ToList()[LastInsertedIndex-1].Priority;
        }

        async void AddBtn_Clicked(System.Object sender, System.EventArgs e)
		{
			try
			{
                var con = DependencyService.Get<ISqlLiteConnection>().GetConnection();
                
                if (PickDate.Text == null)
                {
                    await DisplayAlert("Alert", "Created Date is set to today", "OK");
                    PickDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                }
                var obj = new ToDo()
                {
                    TaskTitle = EntryTaskTitle.Text,
                    TaskDescription = EntryTaskDesc.Text,
                    Priority = SelectPriority.SelectedItem.ToString(),
                    CreatedDate = PickDate.Text,
                    CompletedDate = EndDate.Text
                };
                con.Insert(obj);
                con.Close();
            }

            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message+"\nRetry Again", "OK");
            }
            finally
            {
                await DisplayAlert("", "Task Added Successfully", "OK");
                await Navigation.PopAsync();
            }

		}

        void ResetBtn_Clicked(System.Object sender, System.EventArgs e)
        {

        }
    }
}

