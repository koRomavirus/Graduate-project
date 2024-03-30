using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdShift
{
    public int KeyShift { get; set; }

    public string Name { get; set; } = null!;

    public int SystemFlags { get; set; }

    public virtual ICollection<MdContent> MdContents { get; set; } = new List<MdContent>();

    public virtual ICollection<MdShiftTerm> MdShiftTerms { get; set; } = new List<MdShiftTerm>();
}
