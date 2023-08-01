using System;
using System.Collections.Generic;

namespace TMS_API.Models;

public partial class Venue
{
    public long VenueId { get; set; }

    public string? Capacity { get; set; }

    public string? VenueLocation { get; set; }

    public string? VenueType { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
