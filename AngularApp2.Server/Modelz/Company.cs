using System;
using System.Collections.Generic;

namespace AngularApp2.Server.Modelz;

public partial class Company
{
    public int Id { get; set; }

    public string NameCompany { get; set; } = null!;

    public string AddresCompany { get; set; } = null!;
}
