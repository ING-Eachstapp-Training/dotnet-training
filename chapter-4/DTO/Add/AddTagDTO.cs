using System;
using System.ComponentModel.DataAnnotations;

namespace chapter_4.DTO.Add
{
    public class AddTagDTO
    {
        [MaxLength(10, ErrorMessage = "Label cannot exceed 10 characters")]
        public string Label { get; set; }
    }
}

