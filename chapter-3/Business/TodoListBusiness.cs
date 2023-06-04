using System;
using chapter_3.Database;
using chapter_3.Exceptions;
using chapter_3.Models;
using Task = chapter_3.Models.Task;

namespace chapter_3.Business
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
            string title = _askForTitle();
            if (title == null)
            {
                return;
            }

            string description = _askForDescription();

            List<string> tags = _askForTags();
            if (tags == null)
            {
                return;
            }

            Task newTask = new Task(title, description, false);
            _toDoListDB.AddTask(title, description, tags);
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
                    _toDoListDB.ToggleTask(taskId, true);
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
                    _toDoListDB.ToggleTask(taskId, false);
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

                    string newTitle = _askForTitle();
                    if (newTitle == null)
                    {
                        return;
                    }

                    string newDescription = _askForDescription();

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

        private string? _askForTitle()
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine($"You should input a title");
                return null;
            }
            if (title.Length > 30)
            {
                Console.WriteLine($"The title cannot contain more than 30 characters");
                return null;
            }
            return title;
        }

        private string? _askForDescription()
        {
            Console.Write("Enter new task description (if applicable): ");
            string description = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                return null;
            }
            if (description.Length > 100)
            {
                Console.WriteLine($"The title cannot contain more than 100 characters");
                return null;
            }
            return description;
        }

        private List<string>? _askForTags()
        {
            Console.Write("Enter new tags separated by white space (if applicable): ");
            string tags = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(tags) || string.IsNullOrWhiteSpace(tags))
            {
                return new List<string>();
            }

            var tagList = tags.Split(" ");
            if (tagList.Any(tag => tag.Length > 10))
            {
                Console.Write("Each tag can at most contain 10 characters");
                return null;
            }

            return tagList.ToList();
        }
    }
}

