using System;
using chapter_3.Database.Context;
using chapter_3.Database.Models;
using chapter_3.Exceptions;
using chapter_3.Models;
using Task = chapter_3.Models.Task;

namespace chapter_3.Database
{
    public class TodoListDatabase
    {
        private TodoListDBContext _todoListDBContext;

        public TodoListDatabase()
        {
            _todoListDBContext = new TodoListDBContext();
        }

        public List<Task> GetAllTasks()
        {
            var allTasks = _todoListDBContext.Tasks.ToList();
            return allTasks.Select(taskEntity => new Task(taskEntity.Id, taskEntity.Title, taskEntity.Description, taskEntity.IsComplete)).ToList();
        }

        public void AddTask(Task task)
        {
            TaskEntity newTaskEntity = new TaskEntity()
            {
                IsComplete = false,
                Title = task.Title,
                Description = task.Description
            };
            _todoListDBContext.Tasks.Add(newTaskEntity);
            _todoListDBContext.SaveChanges();
        }

        public void ToggleTask(int taskId, bool newIsComplete)
        {
            TaskEntity taskToEdit = _todoListDBContext.Tasks.FirstOrDefault(taskEntity => taskEntity.Id == taskId);

            taskToEdit.IsComplete = newIsComplete;

            _todoListDBContext.Tasks.Update(taskToEdit);
            _todoListDBContext.SaveChanges();
        }

        public void EditTask(int taskId, string newTitle, string? newDescription)
        {
            TaskEntity taskToEdit = _todoListDBContext.Tasks.FirstOrDefault(taskEntity => taskEntity.Id == taskId);

            taskToEdit.Title = newTitle;
            taskToEdit.Description = null;

            _todoListDBContext.Tasks.Update(taskToEdit);
            _todoListDBContext.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            TaskEntity taskToDelete = _todoListDBContext.Tasks.FirstOrDefault(taskEntity => taskEntity.Id == taskId);

            _todoListDBContext.Tasks.Remove(taskToDelete);
            _todoListDBContext.SaveChanges();
        }

        public Task FindTaskById(int taskId)
        {
            var taskEntity = _todoListDBContext.Tasks.FirstOrDefault(taskEntity => taskEntity.Id == taskId);
            if (taskEntity != null)
            {
                return new Task(taskEntity.Id, taskEntity.Title, taskEntity.Description, taskEntity.IsComplete);
            }
            throw new TaskNotFoundException($"Task with Id {taskId} not found.");
        }
    }
}

