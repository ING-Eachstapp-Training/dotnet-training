using System.Net;
using chapter_4.BL;
using chapter_4.DTO;
using chapter_4.DTO.Add;
using chapter_4.DTO.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chapter_4.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;
    private readonly TasksBL _tasksBL;

    public TaskController(ILogger<TaskController> logger, TasksBL tasksBL)
    {
        _logger = logger;
        _tasksBL = tasksBL;
    }

    [HttpGet]
    public ActionResult<List<TaskDTO>> GetAllTasks()
    {
        _logger.LogInformation("[TaskController][GetAllTasks()] entered controller");
        return new OkObjectResult(_tasksBL.GetAllTasks());
    }

    [HttpPost]
    public ActionResult<List<TaskDTO>> CreateNewTask(AddTaskDTO addTaskDTO)
    {
        _logger.LogInformation("[TaskController][CreateNewTask()] entered controller");
        return new OkObjectResult(_tasksBL.AddNewTask(addTaskDTO));
    }

    [HttpPut]
    public async Task<ActionResult<List<TaskDTO>>> UpdateTaskTaskAsync(UpdateTaskDTO updateTaskDTO)
    {
        _logger.LogInformation("[TaskController][UpdateTaskTask()] entered controller");
        return new OkObjectResult(await _tasksBL.UpdateTask(updateTaskDTO));
    }

    [HttpPut("/ToggleTask")]
    public async Task<ActionResult<List<TaskDTO>>> ToggleTaskAsync(int taskId, bool newIsComplete)
    {
        _logger.LogInformation("[TaskController][ToggleTask()] entered controller");
        return new OkObjectResult(await _tasksBL.ToggleTask(taskId, newIsComplete));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTaskAsync(int taskId)
    {
        _logger.LogInformation("[TaskController][ToggleTask()] entered controller");
        await _tasksBL.DeleteTask(taskId);
        return new NoContentResult();
    }

}

