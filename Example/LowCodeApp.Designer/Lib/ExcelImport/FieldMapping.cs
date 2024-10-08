using Codeer.LowCode.Blazor.Repository.Design;
using Codeer.LowCode.Blazor.Repository.Match;
using static LowCodeApp.Designer.Lib.ExcelImport.Strings;

namespace LowCodeApp.Designer.Lib.ExcelImport
{
    internal class FieldMapping
    {
        private static LinkFieldDesign CreateLinkFieldDesign(string name, string[] args)
        {
            var field = new LinkFieldDesign
            {
                Name = PascalCase(name),
                DbColumn = name,
                SearchCondition =
                {
                    ModuleName = args.GetOrDefault(0)
                },
                ValueVariable = args.GetOrDefault(1),
                DisplayTextVariable = args.GetOrDefault(2)
            };
            return field;
        }

        private static SelectFieldDesign CreateSelectFieldDesign(string name, string[] args)
        {
            var field = new SelectFieldDesign()
            {
                Name = PascalCase(name),
                DbColumn = name
            };
            if (args.GetOrDefault(0) == "$Candidate")
            {
                field.Candidates = args.Skip(1).ToList();
            }
            else
            {
                field.SearchCondition.ModuleName = args.GetOrDefault(0);
                field.ValueVariable = args.GetOrDefault(1);
                field.DisplayTextVariable = args.GetOrDefault(2);
            }

            return field;
        }

        private static ListFieldDesign CreateListFieldDesign(string name, string[] args)
        {
            var fieldName = PascalCase(name) + "List" + args.GetOrDefault(0);
            var field = new ListFieldDesign
            {
                CanCreate = true,
                CanDelete = true,
                CanUpdate = true,
                Name = fieldName,
                SearchCondition =
                {
                    ModuleName = args.GetOrDefault(0)
                }
            };

            var condition = args.GetOrDefault(1).Split(",");
            if (condition.Length >= 2)
            {
                field.SearchCondition.Condition = new MultiMatchCondition()
                {
                    Children =
                    [
                        new FieldMatchCondition
                        {
                            FieldName = fieldName,
                            Children =
                            [
                                new FieldVariableMatchCondition
                                {
                                    SearchTargetVariable = condition[0].Trim(),
                                    Variable = condition[1].Trim(),
                                    Comparison = MatchComparison.Equal
                                }
                            ]
                        }
                    ]
                };
            }

            return field;
        }

        internal static FieldDesignBase MapToFieldDesign(string name, string type, string[] args)
        {
            return type switch
            {
                "Id" => new IdFieldDesign { Name = PascalCase(name), DbColumn = name, },
                "Text" => new TextFieldDesign { Name = PascalCase(name), DbColumn = name, },
                "Number" => new NumberFieldDesign { Name = PascalCase(name), DbColumn = name, },
                "Date" => new DateFieldDesign() { Name = PascalCase(name), DbColumn = name, },
                "DateTime" => new DateTimeFieldDesign() { Name = PascalCase(name), DbColumn = name, },
                "Time" => new TimeFieldDesign() { Name = PascalCase(name), DbColumn = name, },
                "Boolean" => new BooleanFieldDesign() { Name = PascalCase(name), DbColumn = name, },
                "Link" => CreateLinkFieldDesign(name, args),
                "Select" => CreateSelectFieldDesign(name, args),
                "RadioGroup" => new RadioGroupFieldDesign() { Name = PascalCase(name), DbColumn = name },
                "List" => CreateListFieldDesign(name, args),
                _ => throw new Exception($"field type is not supported: {type}")
            };
        }

        internal static RadioButtonFieldDesign[] MapRadioButtons(string name, string[] args)
        {
            return args.Select((s, i) =>
            {
                var parameters = s.Split(',');
                return new RadioButtonFieldDesign()
                {
                    Name = PascalCase(name) + "Item" + i,
                    GroupField = PascalCase(name),
                    Text = parameters.GetOrDefault(0),
                    Value = parameters.GetOrDefault(1)
                };
            }).ToArray();
        }
    }
}
