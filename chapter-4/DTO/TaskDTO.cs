using System;
using AutoMapper;
using chapter_4.Data.Models;

namespace chapter_4.DTO
{
    [AutoMap(typeof(Data.Models.Task))]
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
        public List<TagDTO> Tags { get; set; }
    }
}

