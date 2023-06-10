using System;
using System.ComponentModel.DataAnnotations;

namespace chapter_4.DTO.Update
{
    public class UpdateTaskDTO
    {
        public int TaskId { get; set; }
        [MaxLength(30, ErrorMessage = "Title cannot exceed 30 characters")]
        public string Title { get; set; }
        [MaxLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
        public string? Description { get; set; }
    }
}

