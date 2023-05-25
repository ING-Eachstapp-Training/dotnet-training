using System;
using System.Threading.Tasks;
using chapter_2.Models;
using chapter_2.Exceptions;
using Task = chapter_2.Models.Task;

namespace chapter_2.Database
{
    class TodoListDatabase
    {
        private List<Task> tasks;

        public TodoListDatabase()
        {
            tasks = new List<Task>();
        }

        public List<Task> GetAllTasks()
        {
            return new List<Task>(tasks);
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void CompleteTask(int taskId)
        {
            Task task = FindTaskById(taskId);

            task.isComplete = true;
        }

        public void UncompleteTask(int taskId)
        {
            Task task = FindTaskById(taskId);

            task.isComplete = false;
        }

        public void EditTask(int taskId, string newTitle, string newDescription)
        {
            Task task = FindTaskById(taskId);

            task.Title = newTitle;

            if (task is ComplexTask)
            {
                ((ComplexTask)task).Description = newDescription;
            }

        }

        public void DeleteTask(int taskId)
        {
            Task task = FindTaskById(taskId);

            tasks.Remove(task);
        }

        public Task FindTaskById(int taskId)
        {
            foreach (Task task in tasks)
            {
                if (task.Id == taskId)
                {
                    return task;
                }
            }

            throw new TaskNotFoundException($"Task with Id {taskId} not found.");
        }

        public int GetTasksCount()
        {
            return tasks.Count();
        }
    }
}
