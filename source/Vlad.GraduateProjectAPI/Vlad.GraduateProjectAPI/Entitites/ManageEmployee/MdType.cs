using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdType
{
    public int KeyType { get; set; }

    public string? Name { get; set; }

    public int Flags { get; set; }

    public virtual ICollection<MdMode> MdModes { get; set; } = new List<MdMode>();
}
