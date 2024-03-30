using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdShiftTerm
{
    public int KeyShiftTerm { get; set; }

    /// <summary>
    /// время начала
    /// </summary>
    public TimeOnly? TimeStart { get; set; }

    /// <summary>
    /// время окончания
    /// </summary>
    public TimeOnly? TimeFinish { get; set; }

    /// <summary>
    /// смена
    /// </summary>
    public int KeyShift { get; set; }

    /// <summary>
    /// номер периода
    /// </summary>
    public int? NumTerm { get; set; }

    public virtual MdShift KeyShiftNavigation { get; set; } = null!;
}
