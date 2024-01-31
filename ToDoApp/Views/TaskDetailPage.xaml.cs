using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDoApp.Views
{	
	public partial class TaskDetailPage : ContentPage
	{	
		public TaskDetailPage (string Title, string Description, string priority, string createdDate, string completedDate)
		{
            InitializeComponent();
            ToDoTitle.Text = Title;
            ToDoDescription.Text = Description;
            ToDoPriority.Text = priority;
            CreatedDate.Text = createdDate;
            CompletedDate.Text = completedDate;
        }
	}
}

