using System;
using System.ComponentModel.DataAnnotations;

namespace chapter_4.DTO.Add
{
    public class AddTaskDTO
    {
        [MaxLength(25, ErrorMessage = "Title cannot exceed 25 characters")]
        [MinLength(3, ErrorMessage = "Title cannot exceed 3 characters")]
        [Required]
        public string Title { get; set; }
    }
}

