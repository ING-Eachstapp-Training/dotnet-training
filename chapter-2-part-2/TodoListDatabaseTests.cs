namespace chapter_2_part_2;

using chapter_2.Database;
using chapter_2.Exceptions;
using chapter_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class TodoListDatabaseTests
{
    private TodoListDatabase todoListDatabase;

    [TestInitialize]
    public void TestSetup()
    {
        // This method runs before each test method
        todoListDatabase = new TodoListDatabase();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        // This method runs after each test method
        todoListDatabase = null;
    }

    [TestMethod]
    public void AddTask_ValidTask_TaskAddedToList()
    {
        // Arrange
        SimpleTask task = new SimpleTask(1, "Sample Task");

        // Act
        todoListDatabase.AddTask(task);

        // Assert
        List<Task> allTasks = todoListDatabase.GetAllTasks();
        Assert.IsTrue(allTasks.Contains(task));
    }

    [TestMethod]
    public void CompleteTask_ValidTask_TaskMarkedAsComplete()
    {
        // Arrange
        SimpleTask task = new SimpleTask(1, "Sample Task");
        todoListDatabase.AddTask(task);

        // Act
        todoListDatabase.CompleteTask(task.Id);

        // Assert
        Task completedTask = todoListDatabase.FindTaskById(task.Id);
        Assert.IsTrue(completedTask.IsComplete);
    }

    [TestMethod]
    public void UncompleteTask_ValidTask_TaskMarkedAsIncomplete()
    {
        // Arrange
        SimpleTask task = new SimpleTask(1, "Sample Task");
        todoListDatabase.AddTask(task);
        todoListDatabase.CompleteTask(task.Id);

        // Act
        todoListDatabase.UncompleteTask(task.Id);

        // Assert
        Task uncompletedTask = todoListDatabase.FindTaskById(task.Id);
        Assert.IsFalse(uncompletedTask.IsComplete);
    }

    [TestMethod]
    public void EditTask_ValidSimpleTask_TaskTitleUpdated()
    {
        // Arrange
        SimpleTask task = new SimpleTask(1, "Sample Task");
        todoListDatabase.AddTask(task);

        // Act
        string newTitle = "Updated Task";
        todoListDatabase.EditTask(task.Id, newTitle, null);

        // Assert
        Task updatedTask = todoListDatabase.FindTaskById(task.Id);
        Assert.AreEqual(newTitle, updatedTask.Title);
    }

    [TestMethod]
    public void EditTask_ValidComplexTask_TaskTitleAndDescriptionUpdated()
    {
        // Arrange
        ComplexTask task = new ComplexTask(1, "Sample Task", "Initial Description");
        todoListDatabase.AddTask(task);

        // Act
        string newTitle = "Updated Task";
        string newDescription = "Updated Description";
        todoListDatabase.EditTask(task.Id, newTitle, newDescription);

        // Assert
        Task updatedTask = todoListDatabase.FindTaskById(task.Id);
        Assert.AreEqual(newTitle, updatedTask.Title);
        Assert.AreEqual(newDescription, ((ComplexTask)updatedTask).Description);
    }

    [TestMethod]
    public void DeleteTask_ValidTask_TaskRemovedFromList()
    {
        // Arrange
        SimpleTask task = new SimpleTask(1, "Sample Task");
        todoListDatabase.AddTask(task);

        // Act
        todoListDatabase.DeleteTask(task.Id);

        // Assert
        List<Task> allTasks = todoListDatabase.GetAllTasks();
        Assert.IsFalse(allTasks.Contains(task));
    }

    [TestMethod]
    public void FindTaskById_ExistingTaskId_ReturnsTask()
    {
        // Arrange
        SimpleTask task = new SimpleTask(1, "Sample Task");
        todoListDatabase.AddTask(task);

        // Act
        Task foundTask = todoListDatabase.FindTaskById(task.Id);

        // Assert
        Assert.AreEqual(task, foundTask);
    }

    [TestMethod]
    public void FindTaskById_NonExistingTaskId_ThrowsTaskNotFoundException()
    {
        // Arrange
        int nonExistingTaskId = 100;

        // Act & Assert
        Assert.ThrowsException<TaskNotFoundException>(() => todoListDatabase.FindTaskById(nonExistingTaskId));
    }

    [TestMethod]
    public void GetTasksCount_AddingMultipleTasks_ReturnsCorrectCount()
    {
        // Arrange
        SimpleTask task1 = new SimpleTask(1, "Task 1");
        SimpleTask task2 = new SimpleTask(2, "Task 2");
        SimpleTask task3 = new SimpleTask(3, "Task 3");
        todoListDatabase.AddTask(task1);
        todoListDatabase.AddTask(task2);
        todoListDatabase.AddTask(task3);

        // Act
        int tasksCount = todoListDatabase.GetTasksCount();

        // Assert
        Assert.AreEqual(3, tasksCount);
    }

    [DataTestMethod]
    [DataRow(1, "Task 1")]
    [DataRow(2, "Task 2")]
    [DataRow(3, "Task 3")]
    public void FindTaskById_ExistingTaskId_ReturnsCorrectTask(int taskId, string taskTitle)
    {
        // Arrange
        SimpleTask task = new SimpleTask(taskId, taskTitle);
        todoListDatabase.AddTask(task);

        // Act
        Task foundTask = todoListDatabase.FindTaskById(taskId);

        // Assert
        Assert.AreEqual(task, foundTask);
    }
}
