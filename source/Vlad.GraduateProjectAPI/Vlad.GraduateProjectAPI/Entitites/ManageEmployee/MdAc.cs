using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdAc
{
    public int KeyAcs { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// тип базы данных СКД
    /// </summary>
    public string? Dbtype { get; set; }

    public string? SysName { get; set; }

    public virtual ICollection<MdAcsevent> MdAcsevents { get; set; } = new List<MdAcsevent>();
}
