using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdShedule
{
    public int KeyShedule { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// режим
    /// </summary>
    public int? KeyMode { get; set; }

    /// <summary>
    /// дата отсчета графика
    /// </summary>
    public DateOnly? DateTiming { get; set; }

    /// <summary>
    /// номер дня режима, с кот. отсчет
    /// </summary>
    public int? NumDayMode { get; set; }

    /// <summary>
    /// синкод 1С
    /// </summary>
    public string? SynCode { get; set; }

    public virtual MdMode? KeyModeNavigation { get; set; }

    public virtual ICollection<MdSheduleContent> MdSheduleContents { get; set; } = new List<MdSheduleContent>();

    public virtual ICollection<MdSheduleWorker> MdSheduleWorkers { get; set; } = new List<MdSheduleWorker>();
}
