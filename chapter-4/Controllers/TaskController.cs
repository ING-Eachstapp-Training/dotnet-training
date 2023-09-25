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
    [Attributes.AuthorizeAttributes()]
    public ActionResult<List<TaskDTO>> GetAllTasks()
    {
        _logger.LogInformation("[TaskController][GetAllTasks()] entered controller");
        var userId = (Guid)HttpContext.Items["UserId"]!;
        return new OkObjectResult(_tasksBL.GetAllTasks(userId));
    }

    [HttpGet("{taskId}")]
    [Attributes.AuthorizeAttributes()]
    public async Task<ActionResult<TaskDTO>> GetTaskById(Guid taskId)
    {
        _logger.LogInformation("[TaskController][GetTaskById()] entered controller");
        return new OkObjectResult(await _tasksBL.GetTaskById(taskId));
    }

    [HttpPost]
    [Attributes.AuthorizeAttributes()]
    public async Task<ActionResult<TaskDTO>> CreateNewTaskAsync(AddTaskDTO addTaskDTO)
    {
        _logger.LogInformation("[TaskController][CreateNewTask()] entered controller");
        var userId = (Guid)HttpContext.Items["UserId"]!;
        return new OkObjectResult(await _tasksBL.AddNewTaskAsync(userId, addTaskDTO));
    }

    [HttpPut]
    [Attributes.AuthorizeAttributes()]
    public async Task<ActionResult<TaskDTO>> UpdateTaskTaskAsync(UpdateTaskDTO updateTaskDTO)
    {
        _logger.LogInformation("[TaskController][UpdateTaskTask()] entered controller");
        return new OkObjectResult(await _tasksBL.UpdateTask(updateTaskDTO));
    }

    [HttpPut("ToggleTask")]
    [Attributes.AuthorizeAttributes()]
    public async Task<ActionResult<List<TaskDTO>>> ToggleTaskAsync(Guid taskId, bool newIsComplete)
    {
        _logger.LogInformation("[TaskController][ToggleTask()] entered controller");
        return new OkObjectResult(await _tasksBL.ToggleTask(taskId, newIsComplete));
    }

    [HttpDelete]
    [Attributes.AuthorizeAttributes()]
    public async Task<ActionResult> DeleteTaskAsync(Guid taskId)
    {
        _logger.LogInformation("[TaskController][ToggleTask()] entered controller");
        await _tasksBL.DeleteTask(taskId);
        return new NoContentResult();
    }

}

