using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsService.Dtos
{
    public class GenericEventDto
    {
        public string Event { get; set; } = default!;
        // public Guid EventId { get; set; }
        // public DateTime EventDate { get; set; }
    }
}