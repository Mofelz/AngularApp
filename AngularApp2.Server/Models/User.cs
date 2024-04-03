using System;
using System.Collections.Generic;

namespace AngularApp2.Server.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronomic { get; set; }

    public DateTime Birthday { get; set; }

    public string Mail { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}
