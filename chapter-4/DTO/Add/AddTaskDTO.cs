using System;
using System.ComponentModel.DataAnnotations;

namespace chapter_4.DTO.Add
{
    public class AddTaskDTO
    {
        [MaxLength(30, ErrorMessage = "Title cannot exceed 30 characters")]
        public string Title { get; set; }
    }
}

