using System;
using System.Collections.Generic;

namespace DataBase_Test.PostgreSQL;

public partial class Pobject
{
    public Guid Id { get; set; }

    public string String { get; set; } = null!;

    public string Image { get; set; } = null!;

    public decimal Decimal { get; set; }

    public DateTime Date { get; set; }
}
