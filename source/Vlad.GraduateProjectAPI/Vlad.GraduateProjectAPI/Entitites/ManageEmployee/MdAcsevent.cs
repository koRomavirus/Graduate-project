using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdAcsevent
{
    public int KeyAcsevent { get; set; }

    /// <summary>
    /// система контроля доступа, откуда берутся события
    /// </summary>
    public int? KeyAcs { get; set; }

    /// <summary>
    /// key события в СКД
    /// </summary>
    public int? KeyEvent { get; set; }

    /// <summary>
    /// дата события
    /// </summary>
    public DateOnly? Date { get; set; }

    /// <summary>
    /// время события
    /// </summary>
    public TimeOnly? Time { get; set; }

    /// <summary>
    /// физлицо (KSM)
    /// </summary>
    public int? KeyPerson { get; set; }

    /// <summary>
    /// тип события
    /// </summary>
    public int? KeyAcseventType { get; set; }

    public DateTime? DateTime { get; set; }

    public virtual MdAc? KeyAcsNavigation { get; set; }

    public virtual SSubject? KeyPersonNavigation { get; set; }
}
