using System;
namespace chapter_3.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; } = false;
        public List<Tag> Tags { get; set; } = new List<Tag>();


        public Task(int id, string title, string? description, bool isComplete, List<Tag> tags)
        {
            Id = id;
            Title = title;
            Description = description;
            IsComplete = isComplete;
            Tags = tags;
        }

        public Task(string title, string? description, bool isComplete)
        {
            Title = title;
            Description = description;
            IsComplete = isComplete;
        }


        public void DisplayTask()
        {
            Console.WriteLine($"[{Id}] - {Title} [{(IsComplete ? "Complete" : "Uncomplete")}]");
            if (!string.IsNullOrEmpty(Description))
            {
                Console.WriteLine($"--> {Description}");
            }
            if (Tags.Count() > 0)
            {
                Console.WriteLine($"--> {string.Join(" ; ", Tags.Select(tag => $"#{tag.Label}"))}");
            }
        }
    }
}

