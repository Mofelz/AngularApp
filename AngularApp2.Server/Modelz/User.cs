using System;
using System.Collections.Generic;

namespace AngularApp2.Server.Modelz;

public partial class User
{
    public int Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}
