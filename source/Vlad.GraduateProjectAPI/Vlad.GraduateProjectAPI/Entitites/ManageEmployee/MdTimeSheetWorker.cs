using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdTimeSheetWorker
{
    public int KeyTimeSheetWorker { get; set; }

    public int KeyTimeSheet { get; set; }

    /// <summary>
    /// Сотрудник
    /// </summary>
    public int? KeyWorker { get; set; }

    public int? KeyStaffHistory { get; set; }

    public byte[] Timestamp { get; set; } = null!;

    public virtual WsStaffHistory? KeyStaffHistoryNavigation { get; set; }

    public virtual MdTimeSheet KeyTimeSheetNavigation { get; set; } = null!;

    public virtual WsWorker? KeyWorkerNavigation { get; set; }

    public virtual ICollection<MdTimeSheetDay> MdTimeSheetDays { get; set; } = new List<MdTimeSheetDay>();
}
