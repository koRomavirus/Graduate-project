using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

/// <summary>
/// Перечень технологические операции на рабочем месте
/// </summary>
public partial class WsOperation
{
    public int KeyWsoperation { get; set; }

    public int KeyWorkStation { get; set; }

    public int KeyCttoperation { get; set; }

    public virtual WsWorkStation KeyWorkStationNavigation { get; set; } = null!;
}
