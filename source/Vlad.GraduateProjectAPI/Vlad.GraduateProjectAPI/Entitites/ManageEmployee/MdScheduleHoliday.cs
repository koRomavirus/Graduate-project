using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdScheduleHoliday
{
    public int KeyScheduleHolidays { get; set; }

    /// <summary>
    /// запланированная дата начала отпуска
    /// </summary>
    public DateOnly? Dstart { get; set; }

    /// <summary>
    /// заплпнированная дата окончания отпуска
    /// </summary>
    public DateOnly? Dfinish { get; set; }

    /// <summary>
    /// сотрудник
    /// </summary>
    public int? KeyWorker { get; set; }

    public int? EventType { get; set; }

    public int? Options { get; set; }

    public int? State { get; set; }

    public virtual WsWorker? KeyWorkerNavigation { get; set; }
}
