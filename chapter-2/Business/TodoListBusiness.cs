using System;
using System.Threading.Tasks;
using chapter_2.Database;
using chapter_2.Models;
using chapter_2.Exceptions;
using Task = chapter_2.Models.Task;

namespace chapter_2.Business
{
    class TodoListBusiness
    {
        private TodoListDatabase _toDoListDB;

        public TodoListBusiness()
        {
            _toDoListDB = new TodoListDatabase();
        }

        public void ViewTasks()
        {
            Console.WriteLine("----- View Tasks -----");
            List<Task> allTasks = _toDoListDB.GetAllTasks();
            if (allTasks.Count() == 0)
            {
                Console.WriteLine("No tasks found");
            }
            else
            {
                foreach (var task in allTasks)
                {
                    task.DisplayTask();
                }
            }
        }

        public void AddTask()
        {
            Console.WriteLine("----- Add Task -----");
            Console.Write("Enter task title: ");
            string title = Console.ReadLine().Trim();
            Console.Write("Enter new task description (if applicable): ");
            string description = Console.ReadLine().Trim();
            Task newTask;
            if (String.IsNullOrEmpty(description))
            {
                newTask = new SimpleTask(GenerateTaskId(), title);
            }
            else
            {
                newTask = new ComplexTask(GenerateTaskId(), title, description);
            }
            _toDoListDB.AddTask(newTask);
            Console.WriteLine("Task added successfully.");
        }

        public void CompleteTask()
        {
            Console.WriteLine("----- Complete Task -----");
            Console.Write("Enter task ID: ");
            int taskId;
            if (int.TryParse(Console.ReadLine(), out taskId))
            {
                try
                {
                    Task taskToComplete = _toDoListDB.FindTaskById(taskId);
                    _toDoListDB.CompleteTask(taskId);
                    Console.WriteLine("Task completed successfully.");
                }
                catch (TaskNotFoundException)
                {
                    Console.WriteLine($"No task with the id {taskId} has been found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid task ID.");
            }
        }

        public void UncompleteTask()
        {
            Console.WriteLine("----- Uncomplete Task -----");
            Console.Write("Enter task ID: ");
            int taskId;
            if (int.TryParse(Console.ReadLine(), out taskId))
            {
                try
                {
                    Task taskToComplete = _toDoListDB.FindTaskById(taskId);
                    _toDoListDB.UncompleteTask(taskId);
                    Console.WriteLine("Task uncompleted successfully.");
                }
                catch (TaskNotFoundException)
                {
                    Console.WriteLine($"No task with the id {taskId} has been found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid task ID.");
            }
        }

        public void EditTask()
        {
            Console.WriteLine("----- Edit Task -----");
            Console.Write("Enter task ID: ");
            int taskId;
            if (int.TryParse(Console.ReadLine(), out taskId))
            {
                try
                {
                    Task taskToComplete = _toDoListDB.FindTaskById(taskId);

                    Console.Write("Enter new task title: ");
                    string newTitle = Console.ReadLine();
                    string newDescription = "";
                    if (taskToComplete is ComplexTask)
                    {
                        Console.Write("Enter new task description: ");
                        newDescription = Console.ReadLine();
                    }
                    _toDoListDB.EditTask(taskId, newTitle, newDescription);

                    Console.WriteLine("Task edited successfully.");
                }
                catch (TaskNotFoundException)
                {
                    Console.WriteLine($"No task with the id {taskId} has been found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid task ID.");
            }
        }

        public void DeleteTask()
        {
            Console.WriteLine("----- Delete Task -----");
            Console.Write("Enter task ID: ");
            int taskId;
            if (int.TryParse(Console.ReadLine(), out taskId))
            {
                try
                {
                    Task taskToComplete = _toDoListDB.FindTaskById(taskId);
                    _toDoListDB.DeleteTask(taskId);

                    Console.WriteLine("Task deleted successfully.");
                }
                catch (TaskNotFoundException)
                {
                    Console.WriteLine($"No task with the id {taskId} has been found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid task ID.");
            }
        }

        private int GenerateTaskId()
        {
            // Generate and return a unique task ID
            int newTaskId = _toDoListDB.GetTasksCount() + 1;
            bool isTaskIdValid = false;
            while (!isTaskIdValid)
            {
                try
                {
                    Task t = _toDoListDB.FindTaskById(newTaskId);
                    newTaskId++;
                }
                catch (TaskNotFoundException)
                {
                    isTaskIdValid = true;
                }
            }
            return newTaskId;
        }
    }
}

