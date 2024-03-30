using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdTimeSheet
{
    public int KeyDoc { get; set; }

    /// <summary>
    /// Подразделение
    /// </summary>
    public int KeyDep { get; set; }

    public virtual SSubject KeyDepNavigation { get; set; } = null!;

    public virtual DocList KeyDocNavigation { get; set; } = null!;

    public virtual ICollection<MdTimeSheetWorker> MdTimeSheetWorkers { get; set; } = new List<MdTimeSheetWorker>();
}
