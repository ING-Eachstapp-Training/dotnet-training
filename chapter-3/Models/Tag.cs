using System;
namespace chapter_3.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public Tag(int id, string label)
        {
            Id = id;
            Label = label;
        }

        public Tag(string label)
        {
            Label = label;
        }
    }
}

