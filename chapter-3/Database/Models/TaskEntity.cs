using System;
using System.ComponentModel.DataAnnotations;

namespace chapter_3.Database.Models
{
    public class TaskEntity
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        public Boolean IsComplete { get; set; }

        public ICollection<TagEntity> TagEntities { get; set; }
    }
}

