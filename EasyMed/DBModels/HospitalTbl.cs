using System;
using System.Collections.Generic;

namespace EasyMed.DBModels;

public partial class HospitalTbl
{
    public int Id { get; set; }

    public string HospitalName { get; set; } = null!;

    public bool IsVisible { get; set; }
}
