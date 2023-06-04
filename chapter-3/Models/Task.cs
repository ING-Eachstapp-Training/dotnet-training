using System;
namespace chapter_3.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; } = false;

        public Task(int id, string title, string? description, bool isComplete)
        {
            Id = id;
            Title = title;
            Description = description;
            IsComplete = isComplete;
        }

        public Task(string title, string? description, bool isComplete)
        {
            Title = title;
            Description = description;
            IsComplete = isComplete;
        }


        public virtual void DisplayTask()
        {
            Console.WriteLine($"[{Id}] - {Title} [{(IsComplete ? "Complete" : "Uncomplete")}]");
            if (!string.IsNullOrEmpty(Description))
            {
                Console.WriteLine($"-->{Description}");
            }
        }
    }
}

