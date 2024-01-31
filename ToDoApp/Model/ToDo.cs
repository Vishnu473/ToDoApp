using System;
using SQLite;

namespace ToDoApp.Model
{
    [Table("ToDo")]
    public class ToDo
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [Column("Task")]
        public string TaskTitle { get; set; }

        [MaxLength(1024)]
        public string TaskDescription { get; set; }

        public string Priority { get; set; }
        public string CreatedDate { get; set; }
        public string CompletedDate { get; set; }
    }
}



