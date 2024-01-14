using System;
using System.Collections.Generic;

namespace EasyMed.DBModels;

public partial class PatientTbl
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public string Address { get; set; } = null!;

    public string PatientCode { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string BloodGroup { get; set; } = null!;

    public int? Organization { get; set; }
}
