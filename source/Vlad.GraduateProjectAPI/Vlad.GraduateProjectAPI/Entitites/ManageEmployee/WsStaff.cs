using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class WsStaff
{
    public int KeyStaff { get; set; }

    /// <summary>
    /// должность
    /// </summary>
    public int? KeyPost { get; set; }

    /// <summary>
    /// РМ
    /// </summary>
    public int? KeyWorkStation { get; set; }

    /// <summary>
    /// количество ставок
    /// </summary>
    public decimal? QtyRate { get; set; }

    public int Flags { get; set; }

    public virtual WsPost? KeyPostNavigation { get; set; }

    public virtual WsWorkStation? KeyWorkStationNavigation { get; set; }

    public virtual ICollection<WsStaffHistory> WsStaffHistories { get; set; } = new List<WsStaffHistory>();
}
