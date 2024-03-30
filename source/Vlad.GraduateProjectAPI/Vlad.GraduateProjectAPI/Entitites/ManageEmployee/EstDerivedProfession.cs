using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class EstDerivedProfession
{
    public int KeyDerivedProfession { get; set; }

    public string? Code { get; set; }

    /// <summary>
    /// 0
    /// </summary>
    public int? IsProfession { get; set; }

    public string? Name { get; set; }
}
