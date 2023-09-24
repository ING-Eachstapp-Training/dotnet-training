using System;
using AutoMapper;
using chapter_4.Data.Context;
using chapter_4.DTO;
using chapter_4.DTO.Add;
using chapter_4.DTO.Update;
using chapter_4.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace chapter_4.DAL.Repositories
{
    public class TasksRepository
    {
        TodoListDBContext _todoListDBContext;
        IMapper _mapper;

        public TasksRepository(TodoListDBContext context, IMapper mapper)
        {
            _todoListDBContext = context;
            _mapper = mapper;
        }

        public async Task<TaskDTO?> GetTaskByTitleAsync(string title)
        {
            var myTask = await _todoListDBContext.Tasks.FirstOrDefaultAsync(task => task.Title.Equals(title));
            return _mapper.Map<chapter_4.Data.Models.Task?, TaskDTO?>(myTask);
        }


        public List<TaskDTO> GetAllTasks(Guid userId)
        {
            var allTasks = _todoListDBContext.Tasks.Where(task => task.UserId == userId).ToList();
            return _mapper.Map<List<Data.Models.Task>, List<TaskDTO>>(allTasks);
        }

        public async Task<TaskDTO> AddTaskAsync(Guid userId, AddTaskDTO addTaskDTO)
        {
            Data.Models.Task newTaskEntity = _mapper.Map<AddTaskDTO, Data.Models.Task>(addTaskDTO);
            newTaskEntity.UserId = userId;
            await _todoListDBContext.Tasks.AddAsync(newTaskEntity);
            return _mapper.Map<Data.Models.Task, TaskDTO>(newTaskEntity);
        }

        public async Task<TaskDTO> ToggleTask(Guid taskId, bool newIsComplete)
        {
            Data.Models.Task taskToEdit = await _todoListDBContext.Tasks.FirstOrDefaultAsync(taskEntity => taskEntity.Id == taskId);

            taskToEdit.IsComplete = newIsComplete;

            _todoListDBContext.Tasks.Update(taskToEdit);
            return _mapper.Map<Data.Models.Task, TaskDTO>(taskToEdit);
        }

        public async Task<TaskDTO> EditTask(UpdateTaskDTO updateTaskDTO)
        {
            Data.Models.Task taskToEdit = await _todoListDBContext.Tasks.FirstOrDefaultAsync(taskEntity => taskEntity.Id == updateTaskDTO.TaskId);

            taskToEdit.Title = updateTaskDTO.Title;

            _todoListDBContext.Tasks.Update(taskToEdit);
            return _mapper.Map<Data.Models.Task, TaskDTO>(taskToEdit);
        }

        public async System.Threading.Tasks.Task DeleteTask(Guid taskId)
        {
            Data.Models.Task taskToDelete = await _todoListDBContext.Tasks.FirstOrDefaultAsync(taskEntity => taskEntity.Id == taskId);

            _todoListDBContext.Tasks.Remove(taskToDelete);
            _todoListDBContext.SaveChanges();
        }

        public async Task<TaskDTO> FindTaskById(Guid taskId)
        {
            var taskEntity = await _todoListDBContext.Tasks.FirstOrDefaultAsync(taskEntity => taskEntity.Id == taskId);
            if (taskEntity != null)
            {
                return _mapper.Map<Data.Models.Task, TaskDTO>(taskEntity);
            }
            throw new TaskNotFoundException($"Task with Id {taskId} not found.");
        }
    }
}

