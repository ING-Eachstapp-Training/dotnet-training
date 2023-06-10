using System;
using AutoMapper;
using chapter_4.Data.Models;

namespace chapter_4.DTO
{
    [AutoMap(typeof(Tag))]
    public class TagDTO
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
}

