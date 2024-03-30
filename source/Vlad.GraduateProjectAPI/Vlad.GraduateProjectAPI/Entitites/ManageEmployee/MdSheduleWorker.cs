using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdSheduleWorker
{
    public int KeySheduleWorker { get; set; }

    public int KeyDoc { get; set; }

    public int? KeyWorker { get; set; }

    public int? KeyShedule { get; set; }

    public virtual DocList KeyDocNavigation { get; set; } = null!;

    public virtual MdShedule? KeySheduleNavigation { get; set; }

    public virtual WsWorker? KeyWorkerNavigation { get; set; }
}
