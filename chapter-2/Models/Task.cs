using System;
namespace chapter_2.Models
{
    abstract class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isComplete { get; set; } = false;

        protected Task(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public abstract void DisplayTask();
    }
}

