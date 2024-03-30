using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdSheduleContent
{
    public int KeySheduleContents { get; set; }

    public int KeyShedule { get; set; }

    /// <summary>
    /// дата строки графика
    /// </summary>
    public DateOnly? Date { get; set; }

    /// <summary>
    /// количество часов
    /// </summary>
    public float? Hours { get; set; }

    public TimeOnly? TimeStart { get; set; }

    public TimeOnly? TimeFinish { get; set; }

    public virtual MdShedule KeySheduleNavigation { get; set; } = null!;
}
