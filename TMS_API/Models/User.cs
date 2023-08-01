using System;
using System.Collections.Generic;

namespace TMS_API.Models;

public partial class User
{
    public long Userid { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
