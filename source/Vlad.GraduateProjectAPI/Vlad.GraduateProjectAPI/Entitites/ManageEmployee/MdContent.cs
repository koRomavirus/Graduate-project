using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdContent
{
    public int KeyModeContents { get; set; }

    public int KeyMode { get; set; }

    /// <summary>
    /// смена
    /// </summary>
    public int? KeyShift { get; set; }

    /// <summary>
    /// номер дня
    /// </summary>
    public int? NumDay { get; set; }

    public virtual MdMode KeyModeNavigation { get; set; } = null!;

    public virtual MdShift? KeyShiftNavigation { get; set; }
}
