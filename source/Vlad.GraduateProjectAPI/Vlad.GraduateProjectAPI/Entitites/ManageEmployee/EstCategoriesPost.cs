using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class EstCategoriesPost
{
    public int KeyCategoryPost { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EstProfession> EstProfessions { get; set; } = new List<EstProfession>();
}
