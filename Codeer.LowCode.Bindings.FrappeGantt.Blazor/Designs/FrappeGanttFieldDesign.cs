using Codeer.LowCode.Bindings.FrappeGantt.Blazor.Components;
using Codeer.LowCode.Bindings.FrappeGantt.Blazor.Fields;
using Codeer.LowCode.Blazor.DesignLogic;
using Codeer.LowCode.Blazor.DesignLogic.Check;
using Codeer.LowCode.Blazor.DesignLogic.Refactor;
using Codeer.LowCode.Blazor.OperatingModel;
using Codeer.LowCode.Blazor.Repository.Data;
using Codeer.LowCode.Blazor.Repository.Design;
using Codeer.LowCode.Blazor.Repository.Match;

namespace Codeer.LowCode.Bindings.FrappeGantt.Blazor.Designs
{
    public class FrappeGanttFieldDesign() : FieldDesignBase(typeof(FrappeGanttFieldDesign).FullName!), IDisplayName,
        ISearchResultsViewFieldDesign
    {
        [Designer]
        public string DisplayName { get; set; } = string.Empty;

        [Designer(Scope = DesignerScope.All, Category = nameof(SearchCondition))]
        public SearchCondition SearchCondition { get; set; } = new();

        [Designer(CandidateType = CandidateType.DetailLayout, Category = nameof(SearchCondition))]
        [Layout(ModuleNameMember = $"{nameof(SearchCondition)}.{nameof(SearchCondition.ModuleName)}")]
        public string DetailLayoutName { get; set; } = "";

        [Designer(CandidateType = CandidateType.Field, Category = nameof(SearchCondition))]
        [ModuleMember(Member = $"{nameof(SearchCondition)}.{nameof(SearchCondition.ModuleName)}")]
        [TargetFieldType(Types = [typeof(IdFieldDesign)])]
        public string IdField { get; set; } = "";

        [Designer(CandidateType = CandidateType.Field, Category = nameof(SearchCondition))]
        [ModuleMember(Member = $"{nameof(SearchCondition)}.{nameof(SearchCondition.ModuleName)}")]
        [TargetFieldType(Types = [typeof(TextFieldDesign)])]
        public string NameField { get; set; } = "";

        [Designer(CandidateType = CandidateType.Field, Category = nameof(SearchCondition))]
        [ModuleMember(Member = $"{nameof(SearchCondition)}.{nameof(SearchCondition.ModuleName)}")]
        [TargetFieldType(Types = [typeof(DateTimeFieldDesign)])]
        public string StartDateField { get; set; } = "";

        [Designer(CandidateType = CandidateType.Field, Category = nameof(SearchCondition))]
        [ModuleMember(Member = $"{nameof(SearchCondition)}.{nameof(SearchCondition.ModuleName)}")]
        [TargetFieldType(Types = [typeof(DateTimeFieldDesign)])]
        public string EndDateField { get; set; } = "";

        [Designer(CandidateType = CandidateType.Field, Category = nameof(SearchCondition))]
        [ModuleMember(Member = $"{nameof(SearchCondition)}.{nameof(SearchCondition.ModuleName)}")]
        [TargetFieldType(Types = [typeof(NumberFieldDesign)])]
        public string ProgressField { get; set; } = "";

        [Designer(CandidateType = CandidateType.Field, Category = nameof(SearchCondition))]
        [ModuleMember(Member = $"{nameof(SearchCondition)}.{nameof(SearchCondition.ModuleName)}")]
        [TargetFieldType(Types = [typeof(NumberFieldDesign)])]
        public string ProcessingCounterField { get; set; } = "";

        [Designer(Scope = DesignerScope.All, Category = nameof(DependenciesModule))]
        public SearchCondition DependenciesModule { get; set; } = new();

        [Designer(CandidateType = CandidateType.Field, Category = nameof(DependenciesModule))]
        [ModuleMember(Member = $"{nameof(DependenciesModule)}.{nameof(DependenciesModule.ModuleName)}")]
        public string DependencySourceIdField { get; set; } = "";

        [Designer(CandidateType = CandidateType.Field, Category = nameof(DependenciesModule))]
        [ModuleMember(Member = $"{nameof(DependenciesModule)}.{nameof(DependenciesModule.ModuleName)}")]
        public string DependencyDestinationIdField { get; set; } = "";

        [Designer(CandidateType = CandidateType.ScriptEvent)]
        public string OnDataChanged { get; set; } = string.Empty;

        public override string GetWebComponentTypeFullName() => typeof(FrappeGanttFieldComponent).FullName!;
        public override string GetSearchWebComponentTypeFullName() => string.Empty;
        public override string GetSearchControlTypeFullName() => string.Empty;
        public override FieldDataBase? CreateData() => null;
        public override FieldBase CreateField() => new FrappeGanttField(this);

        public override List<DesignCheckInfo> CheckDesign(DesignCheckContext context)
        {
            var result = base.CheckDesign(context);
            context.CheckFieldRelativeFieldExistence(Name, nameof(IdField), SearchCondition.ModuleName, IdField).AddTo(result);
            context.CheckFieldRelativeFieldExistence(Name, nameof(NameField), SearchCondition.ModuleName, NameField).AddTo(result);
            context.CheckFieldRelativeFieldExistence(Name, nameof(StartDateField), SearchCondition.ModuleName, StartDateField).AddTo(result);
            context.CheckFieldRelativeFieldExistence(Name, nameof(EndDateField), SearchCondition.ModuleName, EndDateField).AddTo(result);
            context.CheckFieldRelativeFieldExistence(Name, nameof(ProgressField), SearchCondition.ModuleName, ProgressField).AddTo(result);
            context.CheckFieldRelativeFieldExistence(Name, nameof(ProcessingCounterField), SearchCondition.ModuleName, ProcessingCounterField).AddTo(result);
            context.CheckFieldRelativeFieldExistence(Name, nameof(DependencySourceIdField), DependenciesModule.ModuleName, DependencySourceIdField).AddTo(result);
            context.CheckFieldRelativeFieldExistence(Name, nameof(DependencyDestinationIdField), DependenciesModule.ModuleName, DependencyDestinationIdField).AddTo(result);
            context.CheckFieldRelativeModuleLayoutExistence(Name, nameof(DetailLayoutName), SearchCondition.ModuleName, DetailLayoutName).AddTo(result);
            context.CheckFieldFunctionExistence(Name, nameof(OnDataChanged), OnDataChanged, null).AddTo(result);
            result.AddRange(SearchCondition.CheckDesign(context, Name, nameof(SearchCondition)));
            result.AddRange(DependenciesModule.CheckDesign(context, Name, nameof(DependenciesModule)));
            return result;
        }

        public override RenameResult ChangeName(RenameContext context) => context.Builder(base.ChangeName(context))
            .AddLayout(SearchCondition.ModuleName, ModuleLayoutType.Detail, DetailLayoutName,
                value => DetailLayoutName = value)
            .AddField(SearchCondition.ModuleName, IdField, value => IdField = value)
            .AddField(SearchCondition.ModuleName, NameField, value => NameField = value)
            .AddField(SearchCondition.ModuleName, StartDateField, value => StartDateField = value)
            .AddField(SearchCondition.ModuleName, EndDateField, value => EndDateField = value)
            .AddField(SearchCondition.ModuleName, ProgressField, value => ProgressField = value)
            .AddField(SearchCondition.ModuleName, ProcessingCounterField,
                value => ProcessingCounterField = value)
            .AddField(DependenciesModule.ModuleName, DependencySourceIdField, value => DependencySourceIdField = value)
            .AddField(DependenciesModule.ModuleName, DependencyDestinationIdField,
                value => DependencyDestinationIdField = value)
            .AddMatchCondition(SearchCondition)
            .AddMatchCondition(DependenciesModule)
            .Build();
    }
}
