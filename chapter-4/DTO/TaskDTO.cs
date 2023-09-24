using AutoMapper;

namespace chapter_4.DTO
{
    [AutoMap(typeof(Data.Models.Task))]
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
    }
}

