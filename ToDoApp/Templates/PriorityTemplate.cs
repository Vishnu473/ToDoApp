using System;
using Xamarin.Forms;
using ToDoApp.Model;

namespace ToDoApp.Templates
{
    public class PriorityTemplate : DataTemplateSelector
    {
        public DataTemplate NormalPriority { get; set; }
        public DataTemplate MediumPriority { get; set; }
        public DataTemplate HighPriority { get; set; }
        public DataTemplate Completed { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var ToDo = item as ToDo;
            if (ToDo.Priority.Equals("Normal"))
            {
                if (!String.IsNullOrEmpty(ToDo.CompletedDate))
                {
                    return Completed;
                }
                return NormalPriority;
            }
            if (ToDo.Priority.Equals("Medium"))
            {
                if (!String.IsNullOrEmpty(ToDo.CompletedDate))
                {
                    return Completed;
                }
                return MediumPriority;
            }
            if (ToDo.Priority.Equals("High"))
            {
                if (!String.IsNullOrEmpty(ToDo.CompletedDate))
                {
                    return Completed;
                }
                return HighPriority;
            }
            else
            {
                return null;
            }
        }
    }
}

