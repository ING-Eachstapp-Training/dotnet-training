using System;
using System.ComponentModel.DataAnnotations;

namespace chapter_3.Database.Models
{
    public class TagEntity
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Label { get; set; }

        public int TaskEntityId { get; set; }
        public TaskEntity TaskEntity { get; set; }

    }
}

