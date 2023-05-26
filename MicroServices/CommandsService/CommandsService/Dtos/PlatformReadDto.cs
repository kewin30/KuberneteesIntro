using CommandsService.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommandsService.Dtos
{
    public class PlatformReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
