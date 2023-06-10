using System;
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
        public int Id { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        public Boolean IsComplete { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}

