using System;
using System.Collections.Generic;

namespace EventosDB.MVC.Data;

public partial class Event
{
    public int Id { get; set; }

    public int EventHostId { get; set; }

    public string Dates { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual EventHost EventHost { get; set; } = null!;

    public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
}
