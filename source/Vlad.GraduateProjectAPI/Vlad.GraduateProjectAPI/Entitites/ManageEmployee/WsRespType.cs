using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class WsRespType
{
    public int KeyRespType { get; set; }

    public string? Name { get; set; }

    public string? SysName { get; set; }

    public virtual ICollection<WsResponsible> WsResponsibles { get; set; } = new List<WsResponsible>();
}
