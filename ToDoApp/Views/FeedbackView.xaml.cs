using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDoApp.Views
{
    public partial class FeedbackView : ContentPage
    {
        public FeedbackView()
        {
            InitializeComponent();
        }
        async void FeedBackSubmit_Clicked(System.Object sender, System.EventArgs e)
        {
            string feedbackMsg = $"{FeedBackType.Text}\n{FeedBack.Text}";

            await DisplayAlert("FeedBack submitted Successfully", "Thanks for your valuable FeedBack", "OK");
            await Navigation.PopAsync();
        }
    }
}

