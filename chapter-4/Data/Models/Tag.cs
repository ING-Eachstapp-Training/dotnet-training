using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using chapter_4.DTO;
using chapter_4.DTO.Add;

namespace chapter_4.Data.Models
{
    [AutoMap(typeof(AddTagDTO))]
    [AutoMap(typeof(TagDTO))]
    public class Tag
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Label { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

    }
}

