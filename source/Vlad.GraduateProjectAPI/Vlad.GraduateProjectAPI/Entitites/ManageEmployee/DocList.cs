using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class DocList
{
    public int KeyDoc { get; set; }

    /// <summary>
    /// иерархия
    /// </summary>
    public int? KeyParent { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNote { get; set; }

    /// <summary>
    /// Создатель (KSM)
    /// </summary>
    public int KeyUsers { get; set; }

    /// <summary>
    /// Гриф секретности
    /// </summary>
    public int KeyPrivacy { get; set; }

    /// <summary>
    /// Набор бинарных флагов. Младшие два байта зарезервированы документооборотом, старшие два байта предоставлены подсистемам.
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Ограничения сверху
    /// </summary>
    public int Restrictions { get; set; }

    /// <summary>
    /// Дата регистрации в ИСУП
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Фактическая дата документа (по умолчанию = Created).
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Дата окончания действия документа
    /// </summary>
    public DateTime? Finished { get; set; }

    /// <summary>
    /// Внутренний рег.№
    /// </summary>
    public string RegNumDoc { get; set; } = null!;

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    /// <summary>
    /// ... НЕ ПОДДЕРЖИВАЕТСЯ... ??
    /// </summary>
    public int? NumDoc { get; set; }

    /// <summary>
    /// ... НЕ ПОДДЕРЖИВАЕТСЯ... ??
    /// </summary>
    public int? KeySub { get; set; }

    public int KeyNotes { get; set; }

    /// <summary>
    /// Вычисляемое поле. Собирает представление записи.
    /// </summary>
    public string? View { get; set; }

    public string Number { get; set; } = null!;

    /// <summary>
    /// Состояние документа
    /// </summary>
    public int? KeyState { get; set; }

    public virtual ICollection<DocList> InverseKeyParentNavigation { get; set; } = new List<DocList>();

    public virtual DocList? KeyParentNavigation { get; set; }

    public virtual SSubject KeyUsersNavigation { get; set; } = null!;

    public virtual ICollection<MdSheduleWorker> MdSheduleWorkers { get; set; } = new List<MdSheduleWorker>();

    public virtual MdTimeSheet? MdTimeSheet { get; set; }

    public virtual ICollection<MdTimeSheetDay> MdTimeSheetDays { get; set; } = new List<MdTimeSheetDay>();
}
