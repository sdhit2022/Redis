using System;
using System.Collections.Generic;

namespace DataBase_Test.SQL;

public partial class Object
{
    public Guid Id { get; set; }

    public string String { get; set; } = null!;

    public DateTime Date { get; set; }

    public decimal Decimal { get; set; }

    public string Image { get; set; } = null!;
}
