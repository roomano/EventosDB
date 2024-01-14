using System;
using System.Collections.Generic;

namespace EventosDB.MVC.Data;

public partial class Invitation
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public int EventHostId { get; set; }

    public int InvitationTypeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual EventHost EventHost { get; set; } = null!;

    public virtual InvitationType InvitationType { get; set; } = null!;
}
