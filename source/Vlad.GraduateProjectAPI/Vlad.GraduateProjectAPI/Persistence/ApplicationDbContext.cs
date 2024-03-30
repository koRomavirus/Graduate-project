using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Vlad.GraduateProjectAPI.Entitites.ManageEmployee;

namespace Vlad.GraduateProjectAPI.Persistence;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocList> DocLists { get; set; }

    public virtual DbSet<EstCategoriesPost> EstCategoriesPosts { get; set; }

    public virtual DbSet<EstDegreeMechanizationOfLabour> EstDegreeMechanizationOfLabours { get; set; }

    public virtual DbSet<EstDerivedProfession> EstDerivedProfessions { get; set; }

    public virtual DbSet<EstProfession> EstProfessions { get; set; }

    public virtual DbSet<EstProfessionGrade> EstProfessionGrades { get; set; }

    public virtual DbSet<MdAc> MdAcs { get; set; }

    public virtual DbSet<MdAcsevent> MdAcsevents { get; set; }

    public virtual DbSet<MdCalendar> MdCalendars { get; set; }

    public virtual DbSet<MdContent> MdContents { get; set; }

    public virtual DbSet<MdHolidayRest> MdHolidayRests { get; set; }

    public virtual DbSet<MdMode> MdModes { get; set; }

    public virtual DbSet<MdScheduleHoliday> MdScheduleHolidays { get; set; }

    public virtual DbSet<MdShedule> MdShedules { get; set; }

    public virtual DbSet<MdSheduleContent> MdSheduleContents { get; set; }

    public virtual DbSet<MdSheduleWorker> MdSheduleWorkers { get; set; }

    public virtual DbSet<MdShift> MdShifts { get; set; }

    public virtual DbSet<MdShiftTerm> MdShiftTerms { get; set; }

    public virtual DbSet<MdTimeSheet> MdTimeSheets { get; set; }

    public virtual DbSet<MdTimeSheetDay> MdTimeSheetDays { get; set; }

    public virtual DbSet<MdTimeSheetWorker> MdTimeSheetWorkers { get; set; }

    public virtual DbSet<MdType> MdTypes { get; set; }

    public virtual DbSet<SSubject> SSubjects { get; set; }

    public virtual DbSet<WsOperation> WsOperations { get; set; }

    public virtual DbSet<WsOperationsGroup> WsOperationsGroups { get; set; }

    public virtual DbSet<WsPost> WsPosts { get; set; }

    public virtual DbSet<WsRelation> WsRelations { get; set; }

    public virtual DbSet<WsRespType> WsRespTypes { get; set; }

    public virtual DbSet<WsResponsible> WsResponsibles { get; set; }

    public virtual DbSet<WsStaff> WsStaffs { get; set; }

    public virtual DbSet<WsStaffHistory> WsStaffHistories { get; set; }

    public virtual DbSet<WsWorkStation> WsWorkStations { get; set; }

    public virtual DbSet<WsWorker> WsWorkers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.10.99.1; User Id=edu_user; Password=student12345; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocList>(entity =>
        {
            entity.HasKey(e => e.KeyDoc);

            entity.ToTable("Doc_List", tb =>
                {
                    tb.HasComment("");
                    tb.HasTrigger("trDocListFixRoute");
                });

            entity.HasIndex(e => new { e.KeyDoc, e.KeyState }, "IDX_Doc_List_Key_State");

            entity.HasIndex(e => e.Date, "IX_DocList_Date");

            entity.HasIndex(e => e.Date, "IX_DocList_DateInclude");

            entity.HasIndex(e => e.Flags, "IX_DocList_FlagsIncludeRestrictions");

            entity.HasIndex(e => new { e.Date, e.Flags, e.KeyDoc, e.KeyNote, e.KeyUsers, e.Restrictions }, "IX_DocList_Include").IsUnique();

            entity.HasIndex(e => e.KeyDoc, "IX_DocList_KeyDoc_Include_Number").IsUnique();

            entity.HasIndex(e => e.KeyDoc, "IX_DocList_KeyDoc_Include_RegNumDoc").IsUnique();

            entity.HasIndex(e => e.KeyNote, "IX_DocList_KeyNote").HasFillFactor(80);

            entity.HasIndex(e => e.KeyNote, "IX_DocList_KeyNoteInclude");

            entity.HasIndex(e => new { e.KeyNote, e.KeyDoc }, "IX_DocList_KeyNoteKeyDocInclude").IsUnique();

            entity.HasIndex(e => new { e.KeyNote, e.KeyDoc }, "IX_DocList_KeyNoteKeyDocIncludeDate").IsUnique();

            entity.HasIndex(e => e.KeyParent, "IX_DocList_KeyParent");

            entity.HasIndex(e => e.KeyUsers, "IX_DocList_KeyUser").HasFillFactor(80);

            entity.HasIndex(e => new { e.KeyUsers, e.Flags, e.Restrictions }, "IX_DocList_KeyUsersInclude");

            entity.HasIndex(e => e.RegNumDoc, "IX_DocList_Regnum");

            entity.HasIndex(e => new { e.KeyNote, e.Restrictions, e.KeyDoc, e.Flags }, "Idx_DocList_KeyNoteRestrKeyDocFlags").IsUnique();

            entity.HasIndex(e => new { e.KeyDoc, e.Date, e.KeyNote }, "_dta_index_Doc_List_5_2141719178__K1_K9_K3_4_11").IsUnique();

            entity.Property(e => e.KeyDoc)
                .HasComment("")
                .HasColumnName("Key_Doc");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Дата регистрации в ИСУП")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Фактическая дата документа (по умолчанию = Created).")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Finished)
                .HasComment("Дата окончания действия документа")
                .HasColumnType("datetime");
            entity.Property(e => e.Flags).HasComment("Набор бинарных флагов. Младшие два байта зарезервированы документооборотом, старшие два байта предоставлены подсистемам.");
            entity.Property(e => e.KeyNote)
                .HasComment("Вид документа")
                .HasColumnName("Key_Note");
            entity.Property(e => e.KeyNotes)
                .HasComputedColumnSql("([Key_Note])", false)
                .HasColumnName("Key_Notes");
            entity.Property(e => e.KeyParent)
                .HasComment("иерархия")
                .HasColumnName("Key_Parent");
            entity.Property(e => e.KeyPrivacy)
                .HasDefaultValueSql("([dbo].[Doc_GetDefaultPrivacy]())")
                .HasComment("Гриф секретности")
                .HasColumnName("Key_Privacy");
            entity.Property(e => e.KeyState)
                .HasComment("Состояние документа")
                .HasColumnName("Key_State");
            entity.Property(e => e.KeySub)
                .HasComment("... НЕ ПОДДЕРЖИВАЕТСЯ... ??")
                .HasColumnName("Key_Sub");
            entity.Property(e => e.KeyUsers)
                .HasComment("Создатель (KSM)")
                .HasColumnName("Key_Users");
            entity.Property(e => e.NumDoc)
                .HasComment("... НЕ ПОДДЕРЖИВАЕТСЯ... ??")
                .HasColumnName("Num_Doc");
            entity.Property(e => e.Number)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComputedColumnSql("([RegNum_Doc])", false);
            entity.Property(e => e.RegNumDoc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Внутренний рег.№")
                .HasColumnName("RegNum_Doc");
            entity.Property(e => e.Restrictions).HasComment("Ограничения сверху");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.View)
                .HasMaxLength(500)
                .HasComputedColumnSql("([dbo].[Doc_View]([Key_Doc]))", false)
                .HasComment("Вычисляемое поле. Собирает представление записи.");

            entity.HasOne(d => d.KeyParentNavigation).WithMany(p => p.InverseKeyParentNavigation)
                .HasForeignKey(d => d.KeyParent)
                .HasConstraintName("DocList_KeyParent");

            entity.HasOne(d => d.KeyUsersNavigation).WithMany(p => p.DocLists)
                .HasForeignKey(d => d.KeyUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DocList_KeyUsers");
        });

        modelBuilder.Entity<EstCategoriesPost>(entity =>
        {
            entity.HasKey(e => e.KeyCategoryPost);

            entity.ToTable("EST_CategoriesPost");

            entity.Property(e => e.KeyCategoryPost).HasColumnName("Key_CategoryPost");
            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<EstDegreeMechanizationOfLabour>(entity =>
        {
            entity.HasKey(e => e.KeyMechanizationOfLabour);

            entity.ToTable("EST_DegreeMechanizationOfLabour");

            entity.Property(e => e.KeyMechanizationOfLabour).HasColumnName("Key_MechanizationOfLabour");
            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<EstDerivedProfession>(entity =>
        {
            entity.HasKey(e => e.KeyDerivedProfession);

            entity.ToTable("EST_DerivedProfessions");

            entity.Property(e => e.KeyDerivedProfession).HasColumnName("Key_DerivedProfession");
            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.IsProfession).HasComment("0");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<EstProfession>(entity =>
        {
            entity.HasKey(e => e.KeyProfession);

            entity.ToTable("EST_Professions");

            entity.Property(e => e.KeyProfession)
                .HasComment("Ключ.")
                .HasColumnName("Key_Profession");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .HasComment("Код профессии(должности).");
            entity.Property(e => e.ControlNumber).HasComment("Контрольное число.");
            entity.Property(e => e.Flags).HasComment("Флаги:\r\nбит 30- признак нормативности(т.е. строка введена на основе нормативного документа);\r\nбит 31- признак логического удаления.\r\n");
            entity.Property(e => e.FullName)
                .HasMaxLength(500)
                .HasComment("Полное наименование профессии(должности).");
            entity.Property(e => e.Grade).HasComment("Разряд (по-умолчанию). Используется для установки разряда \" Маршрутной карте\" при выборе профессии на операцию.");
            entity.Property(e => e.KeyCategoryPost).HasColumnName("Key_CategoryPost");
            entity.Property(e => e.KeyDocBase).HasColumnName("Key_DocBase");
            entity.Property(e => e.KeyKindsProfessionAndWork).HasColumnName("Key_KindsProfessionAndWork");
            entity.Property(e => e.Okz)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("OKZ");

            entity.HasOne(d => d.KeyCategoryPostNavigation).WithMany(p => p.EstProfessions)
                .HasForeignKey(d => d.KeyCategoryPost)
                .HasConstraintName("FK_EST_Professions_EST_CategoriesPost");
        });

        modelBuilder.Entity<EstProfessionGrade>(entity =>
        {
            entity.HasKey(e => e.KeyProfessionGrades);

            entity.ToTable("EST_ProfessionGrades");

            entity.Property(e => e.KeyProfessionGrades).HasColumnName("Key_ProfessionGrades");
            entity.Property(e => e.KeyProfession).HasColumnName("Key_Profession");

            entity.HasOne(d => d.KeyProfessionNavigation).WithMany(p => p.EstProfessionGrades)
                .HasForeignKey(d => d.KeyProfession)
                .HasConstraintName("FK_EST_ProfessionGrades_EST_Professions");
        });

        modelBuilder.Entity<MdAc>(entity =>
        {
            entity.HasKey(e => e.KeyAcs);

            entity.ToTable("Md_ACS");

            entity.Property(e => e.KeyAcs).HasColumnName("Key_ACS");
            entity.Property(e => e.Dbtype)
                .HasMaxLength(50)
                .HasComment("тип базы данных СКД")
                .HasColumnName("DBType");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SysName).HasMaxLength(50);
        });

        modelBuilder.Entity<MdAcsevent>(entity =>
        {
            entity.HasKey(e => e.KeyAcsevent);

            entity.ToTable("Md_ACSEvents");

            entity.HasIndex(e => new { e.Date, e.KeyPerson }, "Idx_MdACSEvents_Date_KeyPers");

            entity.Property(e => e.KeyAcsevent).HasColumnName("Key_ACSEvent");
            entity.Property(e => e.Date).HasComment("дата события");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.KeyAcs)
                .HasComment("система контроля доступа, откуда берутся события")
                .HasColumnName("Key_ACS");
            entity.Property(e => e.KeyAcseventType)
                .HasComment("тип события")
                .HasColumnName("Key_ACSEventType");
            entity.Property(e => e.KeyEvent)
                .HasComment("key события в СКД")
                .HasColumnName("Key_Event");
            entity.Property(e => e.KeyPerson)
                .HasComment("физлицо (KSM)")
                .HasColumnName("Key_Person");
            entity.Property(e => e.Time).HasComment("время события");

            entity.HasOne(d => d.KeyAcsNavigation).WithMany(p => p.MdAcsevents)
                .HasForeignKey(d => d.KeyAcs)
                .HasConstraintName("FK_Md_ACSEvents_Md_ACS");

            entity.HasOne(d => d.KeyPersonNavigation).WithMany(p => p.MdAcsevents)
                .HasForeignKey(d => d.KeyPerson)
                .HasConstraintName("FK_Md_ACSEvents_S_Subjects");
        });

        modelBuilder.Entity<MdCalendar>(entity =>
        {
            entity.HasKey(e => e.KeyCalendar).HasName("PK_Calendar");

            entity.ToTable("Md_Calendar");

            entity.Property(e => e.KeyCalendar).HasColumnName("Key_Calendar");
            entity.Property(e => e.KeyTypeDay).HasColumnName("Key_Type_Day");
        });

        modelBuilder.Entity<MdContent>(entity =>
        {
            entity.HasKey(e => e.KeyModeContents).HasName("PK_M_Mode_Contents");

            entity.ToTable("Md_Contents");

            entity.Property(e => e.KeyModeContents).HasColumnName("Key_Mode_Contents");
            entity.Property(e => e.KeyMode).HasColumnName("Key_Mode");
            entity.Property(e => e.KeyShift)
                .HasComment("смена")
                .HasColumnName("Key_Shift");
            entity.Property(e => e.NumDay)
                .HasComment("номер дня")
                .HasColumnName("Num_Day");

            entity.HasOne(d => d.KeyModeNavigation).WithMany(p => p.MdContents)
                .HasForeignKey(d => d.KeyMode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("M_Mode_Contents_Key_Mode");

            entity.HasOne(d => d.KeyShiftNavigation).WithMany(p => p.MdContents)
                .HasForeignKey(d => d.KeyShift)
                .HasConstraintName("M_Mode_Contents_Key_Shift");
        });

        modelBuilder.Entity<MdHolidayRest>(entity =>
        {
            entity.HasKey(e => e.KeyHolidayRest).HasName("PK_Md_HolydayRest");

            entity.ToTable("Md_HolidayRest");

            entity.Property(e => e.KeyHolidayRest).HasColumnName("Key_HolidayRest");
            entity.Property(e => e.ActualDate).HasComment("дата актуальностпи остатка");
            entity.Property(e => e.Days).HasComment("количество неизрасходованных дней отпуска");
            entity.Property(e => e.DaysFree).HasComment("количество дней в отпусках без содержания");
            entity.Property(e => e.KeyWorker).HasColumnName("Key_Worker");
            entity.Property(e => e.WorkingYearFinish).HasComment("конец рабочего года");
            entity.Property(e => e.WorkingYearStart).HasComment("начало рабочего года");

            entity.HasOne(d => d.KeyWorkerNavigation).WithMany(p => p.MdHolidayRests)
                .HasForeignKey(d => d.KeyWorker)
                .HasConstraintName("FK_Md_HolydayRest_WS_Workers");
        });

        modelBuilder.Entity<MdMode>(entity =>
        {
            entity.HasKey(e => e.KeyMode).HasName("PK_M_Mode");

            entity.ToTable("Md_Modes");

            entity.Property(e => e.KeyMode).HasColumnName("Key_Mode");
            entity.Property(e => e.KeyType)
                .HasComment("вид режима")
                .HasColumnName("Key_Type");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.KeyTypeNavigation).WithMany(p => p.MdModes)
                .HasForeignKey(d => d.KeyType)
                .HasConstraintName("M_Mode_Key_Type_Mode");
        });

        modelBuilder.Entity<MdScheduleHoliday>(entity =>
        {
            entity.HasKey(e => e.KeyScheduleHolidays).HasName("PK_Md_VacationShedule");

            entity.ToTable("Md_ScheduleHolidays");

            entity.Property(e => e.KeyScheduleHolidays).HasColumnName("Key_ScheduleHolidays");
            entity.Property(e => e.Dfinish)
                .HasComment("заплпнированная дата окончания отпуска")
                .HasColumnName("DFinish");
            entity.Property(e => e.Dstart)
                .HasComment("запланированная дата начала отпуска")
                .HasColumnName("DStart");
            entity.Property(e => e.KeyWorker)
                .HasComment("сотрудник")
                .HasColumnName("Key_Worker");

            entity.HasOne(d => d.KeyWorkerNavigation).WithMany(p => p.MdScheduleHolidays)
                .HasForeignKey(d => d.KeyWorker)
                .HasConstraintName("FK_Md_SheduleHolydays_WS_Workers");
        });

        modelBuilder.Entity<MdShedule>(entity =>
        {
            entity.HasKey(e => e.KeyShedule).HasName("PK_M_Shedule");

            entity.ToTable("Md_Shedules");

            entity.Property(e => e.KeyShedule).HasColumnName("Key_Shedule");
            entity.Property(e => e.DateTiming)
                .HasComment("дата отсчета графика")
                .HasColumnName("Date_Timing");
            entity.Property(e => e.KeyMode)
                .HasComment("режим")
                .HasColumnName("Key_Mode");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NumDayMode)
                .HasComment("номер дня режима, с кот. отсчет")
                .HasColumnName("Num_Day_Mode");
            entity.Property(e => e.SynCode)
                .HasMaxLength(50)
                .HasComment("синкод 1С");

            entity.HasOne(d => d.KeyModeNavigation).WithMany(p => p.MdShedules)
                .HasForeignKey(d => d.KeyMode)
                .HasConstraintName("M_Shedule_Key_Mode");
        });

        modelBuilder.Entity<MdSheduleContent>(entity =>
        {
            entity.HasKey(e => e.KeySheduleContents).HasName("PK_M_Shedule_Contents");

            entity.ToTable("Md_SheduleContents");

            entity.HasIndex(e => e.KeyShedule, "Idx_MdSheduleContenr_KeyShedule_IncKSC_D_H_TS_TF");

            entity.HasIndex(e => e.Date, "Idx_MdSheduleContents_Date");

            entity.Property(e => e.KeySheduleContents).HasColumnName("Key_Shedule_Contents");
            entity.Property(e => e.Date).HasComment("дата строки графика");
            entity.Property(e => e.Hours)
                .HasDefaultValue(0f)
                .HasComment("количество часов");
            entity.Property(e => e.KeyShedule).HasColumnName("Key_Shedule");

            entity.HasOne(d => d.KeySheduleNavigation).WithMany(p => p.MdSheduleContents)
                .HasForeignKey(d => d.KeyShedule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("M_Shedule_Contents_Key_Shedule");
        });

        modelBuilder.Entity<MdSheduleWorker>(entity =>
        {
            entity.HasKey(e => e.KeySheduleWorker).HasName("PK_M_Doc_Mode_Persons");

            entity.ToTable("Md_SheduleWorkers");

            entity.HasIndex(e => new { e.KeyWorker, e.KeyDoc, e.KeyShedule }, "Idx_MdSheduleWorkers_KeyW_KeyDoc_KeySh");

            entity.HasIndex(e => new { e.KeyWorker, e.KeySheduleWorker, e.KeyShedule }, "Idx_MdSheduleWorkers_KeyWorker_KeyShedWork_KeyWork");

            entity.Property(e => e.KeySheduleWorker).HasColumnName("Key_SheduleWorker");
            entity.Property(e => e.KeyDoc).HasColumnName("Key_Doc");
            entity.Property(e => e.KeyShedule).HasColumnName("Key_Shedule");
            entity.Property(e => e.KeyWorker).HasColumnName("Key_Worker");

            entity.HasOne(d => d.KeyDocNavigation).WithMany(p => p.MdSheduleWorkers)
                .HasForeignKey(d => d.KeyDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Md_ShedulePersons_Doc_List");

            entity.HasOne(d => d.KeySheduleNavigation).WithMany(p => p.MdSheduleWorkers)
                .HasForeignKey(d => d.KeyShedule)
                .HasConstraintName("M_Doc_Mode_Persons_Key_Shedule");

            entity.HasOne(d => d.KeyWorkerNavigation).WithMany(p => p.MdSheduleWorkers)
                .HasForeignKey(d => d.KeyWorker)
                .HasConstraintName("FK_Md_SheduleWorkers_WS_Workers");
        });

        modelBuilder.Entity<MdShift>(entity =>
        {
            entity.HasKey(e => e.KeyShift).HasName("PK_M_Shift");

            entity.ToTable("Md_Shifts");

            entity.Property(e => e.KeyShift).HasColumnName("Key_Shift");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MdShiftTerm>(entity =>
        {
            entity.HasKey(e => e.KeyShiftTerm).HasName("PK_M_Shift_Terms");

            entity.ToTable("Md_ShiftTerms");

            entity.Property(e => e.KeyShiftTerm).HasColumnName("Key_Shift_Term");
            entity.Property(e => e.KeyShift)
                .HasComment("смена")
                .HasColumnName("Key_Shift");
            entity.Property(e => e.NumTerm)
                .HasComment("номер периода")
                .HasColumnName("Num_Term");
            entity.Property(e => e.TimeFinish)
                .HasComment("время окончания")
                .HasColumnName("Time_Finish");
            entity.Property(e => e.TimeStart)
                .HasComment("время начала")
                .HasColumnName("Time_Start");

            entity.HasOne(d => d.KeyShiftNavigation).WithMany(p => p.MdShiftTerms)
                .HasForeignKey(d => d.KeyShift)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("M_Shift_Terms_Key_Shift");
        });

        modelBuilder.Entity<MdTimeSheet>(entity =>
        {
            entity.HasKey(e => e.KeyDoc).HasName("PK_M_Time_Sheet");

            entity.ToTable("Md_TimeSheets");

            entity.Property(e => e.KeyDoc)
                .ValueGeneratedNever()
                .HasColumnName("Key_Doc");
            entity.Property(e => e.KeyDep)
                .HasComment("Подразделение")
                .HasColumnName("Key_Dep");

            entity.HasOne(d => d.KeyDepNavigation).WithMany(p => p.MdTimeSheets)
                .HasForeignKey(d => d.KeyDep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("M_Time_Sheet_Key_Dep");

            entity.HasOne(d => d.KeyDocNavigation).WithOne(p => p.MdTimeSheet)
                .HasForeignKey<MdTimeSheet>(d => d.KeyDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("M_Time_Sheet_Key_Doc");
        });

        modelBuilder.Entity<MdTimeSheetDay>(entity =>
        {
            entity.HasKey(e => e.KeyTimeSheetDay).HasName("PK_M_Time_Sheet_Days");

            entity.ToTable("Md_TimeSheetDays");

            entity.HasIndex(e => e.KeyDocDev, "IX_MdTimeSheetDays_KeyDocDev");

            entity.HasIndex(e => new { e.KeyTimeSheetWorker, e.KeyWhtype }, "IX_MdTimeSheetDays_KeyTimeSheetWorkerKeyWHTypeIncludeHours");

            entity.HasIndex(e => e.KeyWhtype, "IX_MdTimeSheetDays_KeyWHType_IncludeKeyTimeSheetWorkerHours");

            entity.HasIndex(e => new { e.KeyTimeSheetWorker, e.Day, e.KeyTimeSheetDay }, "Idx_MdTimeSheetDays_KeyTSW_Day_KeyTSD");

            entity.HasIndex(e => new { e.KeyTimeSheetWorker, e.KeyTimeSheetDay, e.KeyWhtype, e.Day }, "Idx_MdTimeSheetDays_KeyTSW_KeyTSD_KeyWHT_Day_incHours");

            entity.Property(e => e.KeyTimeSheetDay).HasColumnName("Key_TimeSheetDay");
            entity.Property(e => e.Day).HasComment("номер дня месяца");
            entity.Property(e => e.Hours)
                .HasDefaultValue(0f)
                .HasComment("количество часов");
            entity.Property(e => e.KeyDocDev)
                .HasComment("документ отклонение")
                .HasColumnName("Key_Doc_Dev");
            entity.Property(e => e.KeyTimeSheetWorker).HasColumnName("Key_TimeSheetWorker");
            entity.Property(e => e.KeyWhtype)
                .HasComment("тип использования")
                .HasColumnName("Key_WHType");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");

            entity.HasOne(d => d.KeyDocDevNavigation).WithMany(p => p.MdTimeSheetDays)
                .HasForeignKey(d => d.KeyDocDev)
                .HasConstraintName("M_Time_Sheet_Days_Key_Doc");

            entity.HasOne(d => d.KeyTimeSheetWorkerNavigation).WithMany(p => p.MdTimeSheetDays)
                .HasForeignKey(d => d.KeyTimeSheetWorker)
                .HasConstraintName("M_Time_Sheet_Days_Key_Time_Sheet_Persons");
        });

        modelBuilder.Entity<MdTimeSheetWorker>(entity =>
        {
            entity.HasKey(e => e.KeyTimeSheetWorker).HasName("PK_MTimeSheetContents");

            entity.ToTable("Md_TimeSheetWorkers");

            entity.HasIndex(e => e.KeyWorker, "IX_MdTimeSheetWorkers_KeyWorkerInclude");

            entity.HasIndex(e => new { e.KeyTimeSheet, e.KeyTimeSheetWorker, e.KeyWorker }, "Idx_MdTimeSheetWorkers_KeyTS_KeyTSW_KeyW");

            entity.Property(e => e.KeyTimeSheetWorker).HasColumnName("Key_TimeSheetWorker");
            entity.Property(e => e.KeyStaffHistory).HasColumnName("Key_StaffHistory");
            entity.Property(e => e.KeyTimeSheet).HasColumnName("Key_TimeSheet");
            entity.Property(e => e.KeyWorker)
                .HasComment("Сотрудник")
                .HasColumnName("Key_Worker");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");

            entity.HasOne(d => d.KeyStaffHistoryNavigation).WithMany(p => p.MdTimeSheetWorkers)
                .HasForeignKey(d => d.KeyStaffHistory)
                .HasConstraintName("FK_Md_TimeSheetWorkers_WS_StaffHistory");

            entity.HasOne(d => d.KeyTimeSheetNavigation).WithMany(p => p.MdTimeSheetWorkers)
                .HasForeignKey(d => d.KeyTimeSheet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("M_Time_Sheet_Persons_Key_Time_Sheet");

            entity.HasOne(d => d.KeyWorkerNavigation).WithMany(p => p.MdTimeSheetWorkers)
                .HasForeignKey(d => d.KeyWorker)
                .HasConstraintName("FK_Md_TimeSheetPersons_WS_Workers");
        });

        modelBuilder.Entity<MdType>(entity =>
        {
            entity.HasKey(e => e.KeyType).HasName("PK_M_Type_Mode");

            entity.ToTable("Md_Types");

            entity.Property(e => e.KeyType).HasColumnName("Key_Type");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SSubject>(entity =>
        {
            entity.HasKey(e => e.KeySub).HasName("PK_Subjects_Key_Sub");

            entity.ToTable("S_Subjects");

            entity.HasIndex(e => e.KeyClass, "FK_Subjects_Key_Class").HasFillFactor(80);

            entity.HasIndex(e => new { e.KeySubMaster, e.Flags, e.KeySub }, "IDX_SSubjects_KeySubMaster_Flags_KeySub_IncCode").IsUnique();

            entity.HasIndex(e => e.KeySub, "IDX_SSubjects_KeySub_IncCode").IsUnique();

            entity.HasIndex(e => e.Code, "IX_SSubjects_CodSub");

            entity.HasIndex(e => e.KeyClass, "IX_SSubjects_KeyClassInclude");

            entity.HasIndex(e => e.KeySub, "IX_SSubjects_KeySubInclude").IsUnique();

            entity.HasIndex(e => e.KeySubMaster, "IX_SSubjects_KeySubMaster");

            entity.HasIndex(e => new { e.KeySubMaster, e.Flags, e.KeySub, e.Code }, "IX_SSubjects_KeySubMaster_Flags_KeySub_Code").IsUnique();

            entity.HasIndex(e => new { e.KeySubMaster, e.KeySub, e.Flags }, "IX_SSubjects_KeySubMaster_KeySub_Flags_IncNameCode").IsUnique();

            entity.HasIndex(e => new { e.KeySubMaster, e.PDel }, "IX_SSubjects_KeySubMaster_PDel");

            entity.HasIndex(e => new { e.KeySub, e.Name }, "IX_SSubjects_KeySub_Name_IncNameK");

            entity.HasIndex(e => new { e.KeyClass, e.Code }, "IX_S_Subjects").HasFillFactor(80);

            entity.HasIndex(e => new { e.KeyClass, e.NameK }, "IX_S_Subjects_1").HasFillFactor(80);

            entity.HasIndex(e => e.Name, "IX_S_Subjects_2");

            entity.HasIndex(e => e.NameK, "IX_S_Subjects_3");

            entity.HasIndex(e => e.KeySubActual, "IX_S_Subjects_4");

            entity.HasIndex(e => new { e.KeySubMaster, e.KeySub, e.Flags }, "IX_S_Subjects_KeySubMaster_KeySub_Flags").IsUnique();

            entity.HasIndex(e => e.Name, "IX_S_Subjects_NameInclude");

            entity.HasIndex(e => new { e.KeySub, e.Date }, "IX_Subjects_Date").IsUnique();

            entity.HasIndex(e => new { e.KeySubMaster, e.KeySub, e.KeySubActual, e.Name }, "Idx_SSubjects_KSM_KS_KSA_N").IsUnique();

            entity.HasIndex(e => new { e.KeySubMaster, e.KeySub, e.Date }, "Idx_SSubjects_KeySubMast_KeySub_Date_IncNameK").IsUnique();

            entity.HasIndex(e => new { e.KeySub, e.KeySubMaster, e.Date }, "Idx_SSubjects_KeySub_KeySubMast_Date_IncNameK").IsUnique();

            entity.HasIndex(e => e.KeySub, "_dta_index_S_Subjects_17_959915087__K1_7_11").IsUnique();

            entity.HasIndex(e => new { e.KeySub, e.Name }, "_dta_index_S_Subjects_21_959915087__K1_12").IsUnique();

            entity.HasIndex(e => new { e.KeySubMaster, e.Name }, "_dta_index_S_Subjects_5_250952466__K2_K6_8");

            entity.HasIndex(e => e.KeySub, "_dta_index_S_Subjects_5_959915087__K1_11_16_17").IsUnique();

            entity.HasIndex(e => new { e.KeySub, e.Code }, "_dta_index_S_Subjects_5_959915087__K1_K8_7_11_12_16_17").IsUnique();

            entity.HasIndex(e => new { e.KeyClass, e.Flags, e.KeySubActual, e.KeySubMaster, e.KeySub, e.NameActual }, "idx_SSubjects_KeyCkass_Flags_KeySubAc_KeySubMas_KeySub_NameAc_CodeAc").IsUnique();

            entity.HasIndex(e => new { e.KeyClass, e.KeySub, e.Flags }, "idx_SSubjects_KeyCladd_KeySub_Flags_IncName").IsUnique();

            entity.HasIndex(e => new { e.KeyClass, e.Flags, e.KeySubActual }, "idx_SSubjects_KeyClass_Flags_KeySubActual");

            entity.HasIndex(e => new { e.KeySub, e.KeySubActual }, "idx_SSubjects_KeySubKeySuba_IncNameSNameASHortNameCOdeA").IsUnique();

            entity.Property(e => e.KeySub).HasColumnName("Key_Sub");
            entity.Property(e => e.AsContragentView)
                .HasMaxLength(4000)
                .HasComment("Если задано, вместо сбора представления из формализованной инфы используется это");
            entity.Property(e => e.CodSub)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComputedColumnSql("([Code])", false)
                .HasColumnName("Cod_Sub");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasComment("Код");
            entity.Property(e => e.CodeActual)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Comment).HasMaxLength(250);
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Дата начала актуальности версии")
                .HasColumnType("datetime");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Дата создания записи")
                .HasColumnType("datetime");
            entity.Property(e => e.Flags).HasComment("Deleted");
            entity.Property(e => e.KeyClass)
                .HasComment("Класс")
                .HasColumnName("Key_Class");
            entity.Property(e => e.KeySubActual).HasColumnName("Key_SubActual");
            entity.Property(e => e.KeySubMaster)
                .HasComment("Группа")
                .HasColumnName("Key_Sub_Master");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NameActual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NameK)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_K");
            entity.Property(e => e.PDel)
                .HasComment("ИЗБАВИТЬСЯ...Логическое удаление")
                .HasColumnName("P_Del");
            entity.Property(e => e.ShortNameActual)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.View)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComputedColumnSql("([dbo].[S_MasterView]([Key_Sub_Master]))", false)
                .HasComment("Универсальное полное представление записи для использования в метаданных");

            entity.HasOne(d => d.KeySubActualNavigation).WithMany(p => p.InverseKeySubActualNavigation)
                .HasForeignKey(d => d.KeySubActual)
                .HasConstraintName("SSubjects_KeySubActual");

            entity.HasOne(d => d.KeySubMasterNavigation).WithMany(p => p.InverseKeySubMasterNavigation)
                .HasForeignKey(d => d.KeySubMaster)
                .HasConstraintName("Subjects_KeySubMaster");
        });

        modelBuilder.Entity<WsOperation>(entity =>
        {
            entity.HasKey(e => e.KeyWsoperation);

            entity.ToTable("WS_Operations", tb => tb.HasComment("Перечень технологические операции на рабочем месте"));

            entity.HasIndex(e => new { e.KeyWorkStation, e.KeyCttoperation }, "IX_WS_Operations")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.KeyWsoperation).HasColumnName("Key_WSOperation");
            entity.Property(e => e.KeyCttoperation).HasColumnName("Key_CTTOperation");
            entity.Property(e => e.KeyWorkStation).HasColumnName("Key_WorkStation");

            entity.HasOne(d => d.KeyWorkStationNavigation).WithMany(p => p.WsOperations)
                .HasForeignKey(d => d.KeyWorkStation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("WS_Operations_Key_WorkStation");
        });

        modelBuilder.Entity<WsOperationsGroup>(entity =>
        {
            entity.HasKey(e => e.KeyOperationsGroup).HasName("PK_WS_OperationsGroup");

            entity.ToTable("WS_OperationsGroups", tb => tb.HasComment("Перечень видов работ на рабочем месте"));

            entity.HasIndex(e => e.KeyOperationGroup, "IX_WS_Operations_Key_OperationGroup").HasFillFactor(80);

            entity.HasIndex(e => e.KeyWorkStation, "IX_WS_Operations_Key_WrokStation").HasFillFactor(80);

            entity.Property(e => e.KeyOperationsGroup).HasColumnName("Key_OperationsGroup");
            entity.Property(e => e.Capability).HasComment("Мощность, н/ч");
            entity.Property(e => e.KeyOperationGroup)
                .HasComment("Вид работ")
                .HasColumnName("Key_OperationGroup");
            entity.Property(e => e.KeyWorkStation)
                .HasComment("Рабочее место")
                .HasColumnName("Key_WorkStation");

            entity.HasOne(d => d.KeyWorkStationNavigation).WithMany(p => p.WsOperationsGroups)
                .HasForeignKey(d => d.KeyWorkStation)
                .HasConstraintName("WS_OperationsGroups_Key_WorkStation");
        });

        modelBuilder.Entity<WsPost>(entity =>
        {
            entity.HasKey(e => e.KeyPost);

            entity.ToTable("WS_Posts");

            entity.Property(e => e.KeyPost).HasColumnName("Key_Post");
            entity.Property(e => e.KeyProfession)
                .HasComment("профессия по ОКПДТР")
                .HasColumnName("Key_Profession");
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.KeyProfessionNavigation).WithMany(p => p.WsPosts)
                .HasForeignKey(d => d.KeyProfession)
                .HasConstraintName("FK_WS_Posts_EST_Professions");
        });

        modelBuilder.Entity<WsRelation>(entity =>
        {
            entity.HasKey(e => e.KeyWsrelation);

            entity.ToTable("WS_Relations");

            entity.HasIndex(e => e.KeyWsparent, "IDX_WSRelations");

            entity.HasIndex(e => e.KeyWsparent, "IDX_WS_Relations");

            entity.HasIndex(e => e.KeyWschild, "IDX_WS_Relations_Key_WSChild");

            entity.Property(e => e.KeyWsrelation).HasColumnName("Key_WSRelation");
            entity.Property(e => e.KeyWschild)
                .HasComment("потомок")
                .HasColumnName("Key_WSChild");
            entity.Property(e => e.KeyWsparent)
                .HasComment("родитель")
                .HasColumnName("Key_WSParent");

            entity.HasOne(d => d.KeyWschildNavigation).WithMany(p => p.WsRelationKeyWschildNavigations)
                .HasForeignKey(d => d.KeyWschild)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WS_Relations_WS_WorkStations1");

            entity.HasOne(d => d.KeyWsparentNavigation).WithMany(p => p.WsRelationKeyWsparentNavigations)
                .HasForeignKey(d => d.KeyWsparent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WS_Relations_WS_WorkStations");
        });

        modelBuilder.Entity<WsRespType>(entity =>
        {
            entity.HasKey(e => e.KeyRespType);

            entity.ToTable("WS_RespTypes");

            entity.Property(e => e.KeyRespType).HasColumnName("Key_RespType");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SysName).HasMaxLength(50);
        });

        modelBuilder.Entity<WsResponsible>(entity =>
        {
            entity.HasKey(e => e.KeyResponsible);

            entity.ToTable("WS_Responsibles");

            entity.HasIndex(e => e.KeyRespType, "IX_WSResponsibles_KeyRespType");

            entity.HasIndex(e => e.KeySub, "IX_WSResponsibles_KeySub");

            entity.HasIndex(e => e.KeyWorkStation, "IX_WSResponsibles_KeyWorkStation");

            entity.Property(e => e.KeyResponsible).HasColumnName("Key_Responsible");
            entity.Property(e => e.KeyRespType).HasColumnName("Key_RespType");
            entity.Property(e => e.KeySub).HasColumnName("Key_Sub");
            entity.Property(e => e.KeyWorkStation).HasColumnName("Key_WorkStation");

            entity.HasOne(d => d.KeyRespTypeNavigation).WithMany(p => p.WsResponsibles)
                .HasForeignKey(d => d.KeyRespType)
                .HasConstraintName("FK_WS_Responsibles_WS_RespTypes");

            entity.HasOne(d => d.KeySubNavigation).WithMany(p => p.WsResponsibles)
                .HasForeignKey(d => d.KeySub)
                .HasConstraintName("FK_WS_Responsibles_S_Subjects");

            entity.HasOne(d => d.KeyWorkStationNavigation).WithMany(p => p.WsResponsibles)
                .HasForeignKey(d => d.KeyWorkStation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WS_Responsibles_WS_WorkStations");
        });

        modelBuilder.Entity<WsStaff>(entity =>
        {
            entity.HasKey(e => e.KeyStaff).HasName("PK_WS_EstablishedPosts");

            entity.ToTable("WS_Staff");

            entity.HasIndex(e => new { e.KeyStaff, e.KeyWorkStation }, "IDX_WS_Staff");

            entity.HasIndex(e => new { e.KeyWorkStation, e.KeyStaff }, "Idx_WS_Staff_KeyWS_KeyStaff_incFlag");

            entity.Property(e => e.KeyStaff).HasColumnName("Key_Staff");
            entity.Property(e => e.KeyPost)
                .HasComment("должность")
                .HasColumnName("Key_Post");
            entity.Property(e => e.KeyWorkStation)
                .HasComment("РМ")
                .HasColumnName("Key_WorkStation");
            entity.Property(e => e.QtyRate)
                .HasDefaultValue(1m)
                .HasComment("количество ставок")
                .HasColumnType("numeric(18, 2)");

            entity.HasOne(d => d.KeyPostNavigation).WithMany(p => p.WsStaffs)
                .HasForeignKey(d => d.KeyPost)
                .HasConstraintName("FK_WS_EstablishedPosts_WS_Posts");

            entity.HasOne(d => d.KeyWorkStationNavigation).WithMany(p => p.WsStaffs)
                .HasForeignKey(d => d.KeyWorkStation)
                .HasConstraintName("FK_WS_EstablishedPosts_WS_WorkStations");
        });

        modelBuilder.Entity<WsStaffHistory>(entity =>
        {
            entity.HasKey(e => e.KeyStaffHistory).HasName("PK_WS_Work");

            entity.ToTable("WS_StaffHistory");

            entity.HasIndex(e => new { e.KeyWorker, e.KeyStaff }, "IDX_WS_StaffHistory");

            entity.HasIndex(e => new { e.KeyStaff, e.KeyWorker }, "Idx_WSStaffHistory_KeyStaff_KeyWorker_IncFlags");

            entity.HasIndex(e => new { e.KeyWorker, e.KeyStaffHistory, e.Dstart, e.Dfinish }, "Idx_WSStaffHistory_KeyW_KeySH_DStart_DFinish");

            entity.Property(e => e.KeyStaffHistory).HasColumnName("Key_StaffHistory");
            entity.Property(e => e.Dfinish)
                .HasComment("дата окончания работы")
                .HasColumnName("DFinish");
            entity.Property(e => e.Dstart)
                .HasComment("дата начала работы")
                .HasColumnName("DStart");
            entity.Property(e => e.KeyDoc).HasColumnName("Key_Doc");
            entity.Property(e => e.KeyStaff)
                .HasComment("штатная единица")
                .HasColumnName("Key_Staff");
            entity.Property(e => e.KeyWorker)
                .HasComment("сотрудник")
                .HasColumnName("Key_Worker");
            entity.Property(e => e.QtyRateOccupied)
                .HasDefaultValue(1m)
                .HasComment("количество занимаемых ставок")
                .HasColumnType("numeric(18, 2)");

            entity.HasOne(d => d.KeyStaffNavigation).WithMany(p => p.WsStaffHistories)
                .HasForeignKey(d => d.KeyStaff)
                .HasConstraintName("FK_WS_Work_WS_EstablishedPosts");

            entity.HasOne(d => d.KeyWorkerNavigation).WithMany(p => p.WsStaffHistories)
                .HasForeignKey(d => d.KeyWorker)
                .HasConstraintName("FK_WS_Work_WS_Workers");
        });

        modelBuilder.Entity<WsWorkStation>(entity =>
        {
            entity.HasKey(e => e.KeyWorkStation);

            entity.ToTable("WS_WorkStations", tb => tb.HasComment("Справочник рабочих мест"));

            entity.HasIndex(e => e.KeyOwner, "IX_WS_WorkStations_Key_Owner").HasFillFactor(80);

            entity.Property(e => e.KeyWorkStation).HasColumnName("Key_WorkStation");
            entity.Property(e => e.Capability).HasComment("Мощность, н/ч");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Flags).HasDefaultValue(0);
            entity.Property(e => e.KeyDep)
                .HasComment("KS подразделения 1 к 1")
                .HasColumnName("Key_Dep");
            entity.Property(e => e.KeyOwner)
                .HasComment("Дерево")
                .HasColumnName("Key_Owner");
            entity.Property(e => e.KeySub)
                .HasComment("Ответственный (KSM)")
                .HasColumnName("Key_Sub");
            entity.Property(e => e.KeyWscontrol)
                .HasComment("РМ отвечающие за контроль тех. оперций")
                .HasColumnName("Key_WSControl");
            entity.Property(e => e.KeyWstype)
                .HasComment("тип РМ")
                .HasColumnName("Key_WSType");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SysName).HasMaxLength(50);

            entity.HasOne(d => d.KeyOwnerNavigation).WithMany(p => p.InverseKeyOwnerNavigation)
                .HasForeignKey(d => d.KeyOwner)
                .HasConstraintName("WorkStations_KeyOwner");

            entity.HasOne(d => d.KeyWscontrolNavigation).WithMany(p => p.InverseKeyWscontrolNavigation)
                .HasForeignKey(d => d.KeyWscontrol)
                .HasConstraintName("WS_WorkStations_Key_WSControl");
        });

        modelBuilder.Entity<WsWorker>(entity =>
        {
            entity.HasKey(e => e.KeyWorker);

            entity.ToTable("WS_Workers", tb => tb.HasComment("Список сотрудников на рабочих местах"));

            entity.HasIndex(e => new { e.KeyWorker, e.KeyUser }, "IDX_WS_Workers");

            entity.Property(e => e.KeyWorker).HasColumnName("Key_Worker");
            entity.Property(e => e.Capability).HasComment("ИЗБАВИТЬСЯ...Мощность, н/ч");
            entity.Property(e => e.Dfinish)
                .HasComment("ИЗБАВИТЬСЯ...")
                .HasColumnType("datetime")
                .HasColumnName("DFinish");
            entity.Property(e => e.Dstart)
                .HasComment("ИЗБАВИТЬСЯ...")
                .HasColumnType("datetime")
                .HasColumnName("DStart");
            entity.Property(e => e.KeyUser)
                .HasComment("физлицо (KSM)")
                .HasColumnName("Key_User");
            entity.Property(e => e.KeyWorkStation)
                .HasComment("ИЗБАВИТЬСЯ...Рабочее место")
                .HasColumnName("Key_WorkStation");
            entity.Property(e => e.Post)
                .HasMaxLength(150)
                .HasComment("ИЗБАВИТЬСЯ...  должность");
            entity.Property(e => e.TimeSheetNumber)
                .HasMaxLength(20)
                .HasComment("табельный номер");

            entity.HasOne(d => d.KeyUserNavigation).WithMany(p => p.WsWorkers)
                .HasForeignKey(d => d.KeyUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Workers_KeySub");

            entity.HasOne(d => d.KeyWorkStationNavigation).WithMany(p => p.WsWorkers)
                .HasForeignKey(d => d.KeyWorkStation)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Workers_KeyWorkStation_CD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
