using System;
namespace chapter_2.Models
{
    public abstract class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; } = false;

        protected Task(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public virtual void DisplayTask()
        {
            Console.WriteLine($"[{Id}] - {Title} [{(IsComplete ? "Complete" : "Uncomplete")}]");
        }
    }
}

