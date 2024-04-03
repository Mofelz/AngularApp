using System;
using System.Collections.Generic;

namespace AngularApp2.Server.Models;

public partial class Fio
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronomic { get; set; }

    public string Number { get; set; } = null!;
}
