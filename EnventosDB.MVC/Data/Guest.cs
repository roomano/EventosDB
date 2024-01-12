using System;
using System.Collections.Generic;

namespace EnventosDB.MVC.Data;

public partial class Guest
{
    public int Id { get; set; }

    public string GuestName { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
