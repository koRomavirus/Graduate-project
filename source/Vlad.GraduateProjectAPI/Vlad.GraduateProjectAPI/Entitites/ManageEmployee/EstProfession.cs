using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class EstProfession
{
    /// <summary>
    /// Ключ.
    /// </summary>
    public int KeyProfession { get; set; }

    /// <summary>
    /// Код профессии(должности).
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Контрольное число.
    /// </summary>
    public int? ControlNumber { get; set; }

    /// <summary>
    /// Полное наименование профессии(должности).
    /// </summary>
    public string FullName { get; set; } = null!;

    public string? Okz { get; set; }

    public int? KeyCategoryPost { get; set; }

    public int? KeyKindsProfessionAndWork { get; set; }

    /// <summary>
    /// Разряд (по-умолчанию). Используется для установки разряда &quot; Маршрутной карте&quot; при выборе профессии на операцию.
    /// </summary>
    public int? Grade { get; set; }

    /// <summary>
    /// Флаги:
    /// бит 30- признак нормативности(т.е. строка введена на основе нормативного документа);
    /// бит 31- признак логического удаления.
    /// 
    /// </summary>
    public int? Flags { get; set; }

    public int? KeyDocBase { get; set; }

    public virtual ICollection<EstProfessionGrade> EstProfessionGrades { get; set; } = new List<EstProfessionGrade>();

    public virtual EstCategoriesPost? KeyCategoryPostNavigation { get; set; }

    public virtual ICollection<WsPost> WsPosts { get; set; } = new List<WsPost>();
}
