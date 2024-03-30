using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdTimeSheetDay
{
    public int KeyTimeSheetDay { get; set; }

    public int KeyTimeSheetWorker { get; set; }

    /// <summary>
    /// номер дня месяца
    /// </summary>
    public int? Day { get; set; }

    /// <summary>
    /// количество часов
    /// </summary>
    public float? Hours { get; set; }

    /// <summary>
    /// документ отклонение
    /// </summary>
    public int? KeyDocDev { get; set; }

    /// <summary>
    /// тип использования
    /// </summary>
    public int? KeyWhtype { get; set; }

    public byte[] Timestamp { get; set; } = null!;

    public virtual DocList? KeyDocDevNavigation { get; set; }

    public virtual MdTimeSheetWorker KeyTimeSheetWorkerNavigation { get; set; } = null!;
}
