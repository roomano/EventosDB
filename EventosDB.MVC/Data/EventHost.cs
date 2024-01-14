using System;
using System.Collections.Generic;

namespace EventosDB.MVC.Data;

public partial class EventHost
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
}
