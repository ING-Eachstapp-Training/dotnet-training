namespace chapter_1
{
    class Program
    {
        static List<string> tasks = new List<string>();
        static Dictionary<int, bool> taskStatuses = new Dictionary<int, bool>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                DisplayMenu();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "1":
                        ViewTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        CompleteTask();
                        break;
                    case "4":
                        UncompleteTask();
                        break;
                    case "5":
                        EditTask();
                        break;
                    case "6":
                        DeleteTask();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("======= To-Do List =======");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Uncomplete Task");
            Console.WriteLine("5. Edit Task");
            Console.WriteLine("6. Delete Task");
            Console.WriteLine("7. Exit");
            Console.WriteLine("===========================");
        }

        static void ViewTasks()
        {
            Console.WriteLine("======= Tasks =======");

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    int taskId = tasks.IndexOf(task) + 1;
                    string status = taskStatuses[taskId] ? "Complete" : "Incomplete";
                    Console.WriteLine($"[{taskId}] - {task} ({status})");
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();

            int newId = tasks.Count + 1;
            tasks.Add(description);
            taskStatuses[newId] = false;

            Console.WriteLine("Task added successfully.");
        }

        static void CompleteTask()
        {
            Console.Write("Enter the task ID to mark as complete: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                if (taskId > 0 && taskId <= tasks.Count)
                {
                    taskStatuses[taskId] = true;
                    Console.WriteLine("Task marked as complete.");
                }
                else
                {
                    Console.WriteLine("Invalid task ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        static void UncompleteTask()
        {
            Console.Write("Enter the task ID to mark as incomplete: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                if (taskId > 0 && taskId <= tasks.Count)
                {
                    taskStatuses[taskId] = false;
                    Console.WriteLine("Task marked as incomplete.");
                }
                else
                {
                    Console.WriteLine("Invalid task IDa.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        static void EditTask()
        {
            Console.Write("Enter the task ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                if (taskId > 0 && taskId <= tasks.Count)
                {
                    Console.Write("Enter the new task description: ");


                    string newDescription = Console.ReadLine();

                    tasks[taskId - 1] = newDescription;
                    Console.WriteLine("Task updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid task ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        static void DeleteTask()
        {
            Console.Write("Enter the task ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                if (taskId > 0 && taskId <= tasks.Count)
                {
                    string deletedTask = tasks[taskId - 1];
                    tasks.RemoveAt(taskId - 1);
                    taskStatuses.Remove(taskId);
                    Console.WriteLine($"Task '{deletedTask}' deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid task ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }
    }
}

