using System;
using System.Collections.Generic;

namespace EasyMed.DBModels;

public partial class DoctorTbl
{
    public int Id { get; set; }

    public string DoctorName { get; set; } = null!;

    public string DoctorSpe { get; set; } = null!;

    public string DoctorDeg { get; set; } = null!;
}
