using System;
using System.ComponentModel.DataAnnotations;

namespace chapter_4.DTO.Update
{
    public class UpdateTaskDTO
    {
        public Guid TaskId { get; set; }
        [MaxLength(30, ErrorMessage = "Title cannot exceed 30 characters")]
        public string Title { get; set; }
    }
}

