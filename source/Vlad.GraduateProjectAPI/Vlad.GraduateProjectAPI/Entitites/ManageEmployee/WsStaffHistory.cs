using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class WsStaffHistory
{
    public int KeyStaffHistory { get; set; }

    /// <summary>
    /// штатная единица
    /// </summary>
    public int? KeyStaff { get; set; }

    /// <summary>
    /// сотрудник
    /// </summary>
    public int? KeyWorker { get; set; }

    /// <summary>
    /// дата начала работы
    /// </summary>
    public DateOnly? Dstart { get; set; }

    /// <summary>
    /// дата окончания работы
    /// </summary>
    public DateOnly? Dfinish { get; set; }

    /// <summary>
    /// количество занимаемых ставок
    /// </summary>
    public decimal QtyRateOccupied { get; set; }

    public int? KeyDoc { get; set; }

    public int Flags { get; set; }

    public virtual WsStaff? KeyStaffNavigation { get; set; }

    public virtual WsWorker? KeyWorkerNavigation { get; set; }

    public virtual ICollection<MdTimeSheetWorker> MdTimeSheetWorkers { get; set; } = new List<MdTimeSheetWorker>();
}
