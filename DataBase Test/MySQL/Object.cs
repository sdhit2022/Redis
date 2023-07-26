using System;
using System.Collections.Generic;

namespace DataBase_Test.MySQL;

public partial class Object
{
    public string Id { get; set; } = null!;

    public string String { get; set; } = null!;

    public decimal? Decimal { get; set; }

    public DateTime Date { get; set; }

    public string Image { get; set; } = null!;
}
