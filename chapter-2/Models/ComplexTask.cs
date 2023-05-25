using System;
namespace chapter_2.Models
{
    class ComplexTask : Task
    {
        public string Description { get; set; }
        public ComplexTask(int id, string title, string description) : base(id, title)
        {
            Description = description;
        }

        public override void DisplayTask()
        {
            Console.WriteLine($"[{Id}] - {base.Title} [{(isComplete ? "Complete" : "Uncomplete")}]");
            Console.WriteLine($"-->{Description}");
        }
    }
}

