using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelloGraphQl.Api.Data
{
    public class Track
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Name { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
