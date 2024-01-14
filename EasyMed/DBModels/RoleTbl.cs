using System;
using System.Collections.Generic;

namespace EasyMed.DBModels;

public partial class RoleTbl
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public bool IsActive { get; set; }
}
