using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdHolidayRest
{
    public int KeyHolidayRest { get; set; }

    public int? KeyWorker { get; set; }

    /// <summary>
    /// начало рабочего года
    /// </summary>
    public DateOnly? WorkingYearStart { get; set; }

    /// <summary>
    /// конец рабочего года
    /// </summary>
    public DateOnly? WorkingYearFinish { get; set; }

    /// <summary>
    /// количество неизрасходованных дней отпуска
    /// </summary>
    public double? Days { get; set; }

    /// <summary>
    /// дата актуальностпи остатка
    /// </summary>
    public DateOnly? ActualDate { get; set; }

    /// <summary>
    /// количество дней в отпусках без содержания
    /// </summary>
    public int? DaysFree { get; set; }

    public virtual WsWorker? KeyWorkerNavigation { get; set; }
}
