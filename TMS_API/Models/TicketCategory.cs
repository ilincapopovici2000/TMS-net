using System;
using System.Collections.Generic;

namespace TMS_API.Models;

public partial class TicketCategory
{
    public long TicketCategoryId { get; set; }

    public string? Description { get; set; }

    public float Price { get; set; }

    public long? EventId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
