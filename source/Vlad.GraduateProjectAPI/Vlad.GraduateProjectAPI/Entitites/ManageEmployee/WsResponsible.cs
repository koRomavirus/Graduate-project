using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class WsResponsible
{
    public int KeyResponsible { get; set; }

    public int KeyWorkStation { get; set; }

    public int? KeySub { get; set; }

    public int? KeyRespType { get; set; }

    public virtual WsRespType? KeyRespTypeNavigation { get; set; }

    public virtual SSubject? KeySubNavigation { get; set; }

    public virtual WsWorkStation KeyWorkStationNavigation { get; set; } = null!;
}
