using System;
using System.Collections.Generic;

namespace EventosDB.MVC.Data;

public partial class InvitationType
{
    public int Id { get; set; }

    public string Designation { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
}
