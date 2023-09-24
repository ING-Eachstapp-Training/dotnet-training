using System;
using chapter_4.DAL;
using chapter_4.DTO;
using chapter_4.DTO.Add;
using chapter_4.DTO.Update;
using chapter_4.Exceptions;

namespace chapter_4.BL
{
    public class TasksBL
    {
        private UnitOfWork _uow;
        private readonly ILogger<TasksBL> _logger;


        public TasksBL(UnitOfWork uow, ILogger<TasksBL> logger)
        {
            _uow = uow;
            _logger = logger;
        }

        public List<TaskDTO> GetAllTasks(Guid userId)
        {
            _logger.LogInformation("[TasksBL][GetAllTasks()] entered function");
            return _uow.TasksRepository.GetAllTasks(userId);
        }

        public async Task<TaskDTO> AddNewTaskAsync(Guid userId, AddTaskDTO addTaskDTO)
        {
            _logger.LogInformation("[TasksBL][addTaskDTO()] entered function");

            var newTask = await _uow.TasksRepository.AddTaskAsync(userId, addTaskDTO);
            _uow.Commit();
            return newTask;
        }

        public async Task<TaskDTO> UpdateTask(UpdateTaskDTO updateTaskDTO)
        {
            _logger.LogInformation("[TasksBL][updateTaskDTO()] entered function");

            // Get the task by id (throws an error if it doesn't exist)
            await _uow.TasksRepository.FindTaskById(updateTaskDTO.TaskId);

            var updatedTask = await _uow.TasksRepository.EditTask(updateTaskDTO);
            _uow.Commit();
            return updatedTask;
        }

        public async Task<TaskDTO> ToggleTask(Guid taskId, bool newIsComplete)
        {
            _logger.LogInformation("[TasksBL][ToggleTask()] entered function");

            // Get the task by id (throws an error if it doesn't exist)
            await _uow.TasksRepository.FindTaskById(taskId);

            var toggledTask = await _uow.TasksRepository.ToggleTask(taskId, newIsComplete);
            _uow.Commit();
            return toggledTask;
        }

        public async Task DeleteTask(Guid taskId)
        {
            _logger.LogInformation("[TasksBL][DeleteTask()] entered function");

            // Get the task by id (throws an error if it doesn't exist)
            await _uow.TasksRepository.FindTaskById(taskId);

            await _uow.TasksRepository.DeleteTask(taskId);
            _uow.Commit();
        }
    }
}

