using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class WsPost
{
    public int KeyPost { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// профессия по ОКПДТР
    /// </summary>
    public int? KeyProfession { get; set; }

    public virtual EstProfession? KeyProfessionNavigation { get; set; }

    public virtual ICollection<WsStaff> WsStaffs { get; set; } = new List<WsStaff>();
}
