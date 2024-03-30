using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class WsRelation
{
    public int KeyWsrelation { get; set; }

    /// <summary>
    /// родитель
    /// </summary>
    public int KeyWsparent { get; set; }

    /// <summary>
    /// потомок
    /// </summary>
    public int KeyWschild { get; set; }

    public int PathLength { get; set; }

    public virtual WsWorkStation KeyWschildNavigation { get; set; } = null!;

    public virtual WsWorkStation KeyWsparentNavigation { get; set; } = null!;
}
