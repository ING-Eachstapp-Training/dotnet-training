using System;
namespace chapter_2.Models
{
    public class SimpleTask : Task
    {
        public SimpleTask(int id, string title) : base(id, title) { }

        public override void DisplayTask()
        {
            Console.WriteLine($"[{Id}] - {base.Title} [{(IsComplete ? "Complete" : "Uncomplete")}]");
        }
    }
}

