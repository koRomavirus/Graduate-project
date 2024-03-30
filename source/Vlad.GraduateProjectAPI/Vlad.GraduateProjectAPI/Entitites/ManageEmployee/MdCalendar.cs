using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class MdCalendar
{
    public int KeyCalendar { get; set; }

    public DateOnly? Date { get; set; }

    public int? KeyTypeDay { get; set; }
}
