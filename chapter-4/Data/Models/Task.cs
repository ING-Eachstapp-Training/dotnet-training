using System.ComponentModel.DataAnnotations;
using AutoMapper;
using chapter_4.DTO;
using chapter_4.DTO.Add;

namespace chapter_4.Data.Models
{
    [AutoMap(typeof(AddTaskDTO))]
    [AutoMap(typeof(TaskDTO))]
    public class Task
    {
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        public bool IsComplete { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

