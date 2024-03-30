using System;
using System.Collections.Generic;

namespace Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

/// <summary>
/// Справочник рабочих мест
/// </summary>
public partial class WsWorkStation
{
    public int KeyWorkStation { get; set; }

    /// <summary>
    /// Дерево
    /// </summary>
    public int? KeyOwner { get; set; }

    /// <summary>
    /// тип РМ
    /// </summary>
    public int? KeyWstype { get; set; }

    /// <summary>
    /// KS подразделения 1 к 1
    /// </summary>
    public int? KeyDep { get; set; }

    /// <summary>
    /// Ответственный (KSM)
    /// </summary>
    public int KeySub { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Мощность, н/ч
    /// </summary>
    public double Capability { get; set; }

    public string? SysName { get; set; }

    public int? Flags { get; set; }

    /// <summary>
    /// РМ отвечающие за контроль тех. оперций
    /// </summary>
    public int? KeyWscontrol { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<WsWorkStation> InverseKeyOwnerNavigation { get; set; } = new List<WsWorkStation>();

    public virtual ICollection<WsWorkStation> InverseKeyWscontrolNavigation { get; set; } = new List<WsWorkStation>();

    public virtual WsWorkStation? KeyOwnerNavigation { get; set; }

    public virtual WsWorkStation? KeyWscontrolNavigation { get; set; }

    public virtual ICollection<WsOperation> WsOperations { get; set; } = new List<WsOperation>();

    public virtual ICollection<WsOperationsGroup> WsOperationsGroups { get; set; } = new List<WsOperationsGroup>();

    public virtual ICollection<WsRelation> WsRelationKeyWschildNavigations { get; set; } = new List<WsRelation>();

    public virtual ICollection<WsRelation> WsRelationKeyWsparentNavigations { get; set; } = new List<WsRelation>();

    public virtual ICollection<WsResponsible> WsResponsibles { get; set; } = new List<WsResponsible>();

    public virtual ICollection<WsStaff> WsStaffs { get; set; } = new List<WsStaff>();

    public virtual ICollection<WsWorker> WsWorkers { get; set; } = new List<WsWorker>();
}
