using System;
using System.Collections.Generic;

namespace EventosDB.MVC.Data;

public partial class GuestType
{
    public int Id { get; set; }

    public string Designation { get; set; } = null!;

    public virtual ICollection<Guest> Guests { get; set; } = new List<Guest>();
}
