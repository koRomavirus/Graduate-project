using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class EstProfessionGrade
{
    public int KeyProfessionGrades { get; set; }

    public int? KeyProfession { get; set; }

    public int? Grade { get; set; }

    public virtual EstProfession? KeyProfessionNavigation { get; set; }
}
