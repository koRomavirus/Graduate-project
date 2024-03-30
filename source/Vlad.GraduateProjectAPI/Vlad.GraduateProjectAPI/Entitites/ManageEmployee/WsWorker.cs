using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

/// <summary>
/// Список сотрудников на рабочих местах
/// </summary>
public partial class WsWorker
{
    public int KeyWorker { get; set; }

    /// <summary>
    /// физлицо (KSM)
    /// </summary>
    public int KeyUser { get; set; }

    /// <summary>
    /// табельный номер
    /// </summary>
    public string? TimeSheetNumber { get; set; }

    public int Flags { get; set; }

    /// <summary>
    /// ИЗБАВИТЬСЯ...
    /// </summary>
    public DateTime? Dstart { get; set; }

    /// <summary>
    /// ИЗБАВИТЬСЯ...
    /// </summary>
    public DateTime? Dfinish { get; set; }

    /// <summary>
    /// ИЗБАВИТЬСЯ...Рабочее место
    /// </summary>
    public int? KeyWorkStation { get; set; }

    /// <summary>
    /// ИЗБАВИТЬСЯ...Мощность, н/ч
    /// </summary>
    public double? Capability { get; set; }

    /// <summary>
    /// ИЗБАВИТЬСЯ...  должность
    /// </summary>
    public string? Post { get; set; }

    public virtual SSubject KeyUserNavigation { get; set; } = null!;

    public virtual WsWorkStation? KeyWorkStationNavigation { get; set; }

    public virtual ICollection<MdHolidayRest> MdHolidayRests { get; set; } = new List<MdHolidayRest>();

    public virtual ICollection<MdScheduleHoliday> MdScheduleHolidays { get; set; } = new List<MdScheduleHoliday>();

    public virtual ICollection<MdSheduleWorker> MdSheduleWorkers { get; set; } = new List<MdSheduleWorker>();

    public virtual ICollection<MdTimeSheetWorker> MdTimeSheetWorkers { get; set; } = new List<MdTimeSheetWorker>();

    public virtual ICollection<WsStaffHistory> WsStaffHistories { get; set; } = new List<WsStaffHistory>();
}
