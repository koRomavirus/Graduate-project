using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

public partial class SSubject
{
    public int KeySub { get; set; }

    /// <summary>
    /// Группа
    /// </summary>
    public int? KeySubMaster { get; set; }

    /// <summary>
    /// Класс
    /// </summary>
    public int KeyClass { get; set; }

    /// <summary>
    /// Deleted
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Дата начала актуальности версии
    /// </summary>
    public DateTime Date { get; set; }

    public string Name { get; set; } = null!;

    public string NameK { get; set; } = null!;

    /// <summary>
    /// Код
    /// </summary>
    public string Code { get; set; } = null!;

    public string? Comment { get; set; }

    public int? KeySubActual { get; set; }

    public string? NameActual { get; set; }

    public string? ShortNameActual { get; set; }

    /// <summary>
    /// Универсальное полное представление записи для использования в метаданных
    /// </summary>
    public string? View { get; set; }

    /// <summary>
    /// ИЗБАВИТЬСЯ...Логическое удаление
    /// </summary>
    public byte PDel { get; set; }

    public string CodSub { get; set; } = null!;

    public string? CodeActual { get; set; }

    /// <summary>
    /// Если задано, вместо сбора представления из формализованной инфы используется это
    /// </summary>
    public string? AsContragentView { get; set; }

    public int SystemFlags { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime? DateCreate { get; set; }

    public virtual ICollection<DocList> DocLists { get; set; } = new List<DocList>();

    public virtual ICollection<SSubject> InverseKeySubActualNavigation { get; set; } = new List<SSubject>();

    public virtual ICollection<SSubject> InverseKeySubMasterNavigation { get; set; } = new List<SSubject>();

    public virtual SSubject? KeySubActualNavigation { get; set; }

    public virtual SSubject? KeySubMasterNavigation { get; set; }

    public virtual ICollection<MdAcsevent> MdAcsevents { get; set; } = new List<MdAcsevent>();

    public virtual ICollection<MdTimeSheet> MdTimeSheets { get; set; } = new List<MdTimeSheet>();

    public virtual ICollection<WsResponsible> WsResponsibles { get; set; } = new List<WsResponsible>();

    public virtual ICollection<WsWorker> WsWorkers { get; set; } = new List<WsWorker>();
}
