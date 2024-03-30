using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

/// <summary>
/// Перечень видов работ на рабочем месте
/// </summary>
public partial class WsOperationsGroup
{
    public int KeyOperationsGroup { get; set; }

    /// <summary>
    /// Рабочее место
    /// </summary>
    public int KeyWorkStation { get; set; }

    /// <summary>
    /// Вид работ
    /// </summary>
    public int KeyOperationGroup { get; set; }

    /// <summary>
    /// Мощность, н/ч
    /// </summary>
    public double Capability { get; set; }

    public virtual WsWorkStation KeyWorkStationNavigation { get; set; } = null!;
}
