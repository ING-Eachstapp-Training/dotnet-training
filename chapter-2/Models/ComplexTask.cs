using System;
namespace chapter_2.Models
{
    public class ComplexTask : Task
    {
        public string Description { get; set; }
        public ComplexTask(int id, string title, string description) : base(id, title)
        {
            Description = description;
        }

        public override void DisplayTask()
        {
            base.DisplayTask();
            Console.WriteLine($"-->{Description}");
        }
    }
}

