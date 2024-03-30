using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdMode
{
    public int KeyMode { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// вид режима
    /// </summary>
    public int? KeyType { get; set; }

    public int SystemFlags { get; set; }

    public virtual MdType? KeyTypeNavigation { get; set; }

    public virtual ICollection<MdContent> MdContents { get; set; } = new List<MdContent>();

    public virtual ICollection<MdShedule> MdShedules { get; set; } = new List<MdShedule>();
}
