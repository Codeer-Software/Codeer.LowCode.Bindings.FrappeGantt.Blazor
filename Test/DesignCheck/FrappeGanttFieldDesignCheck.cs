using Codeer.LowCode.Bindings.FrappeGantt.Blazor.Designs;
using Codeer.LowCode.Blazor.DesignLogic.Check;
using Codeer.LowCode.Blazor.Repository.Design;

namespace BindingsTest.DesignCheck
{
    public class FrappeGanttFieldDesignCheck
    {
        [Test]
        public void Success()
        {
            var (designData, module) = Utilities.CreateDesignData();
            var field = new FrappeGanttFieldDesign
            {
                Name = "FrappeGantt1",
                DetailLayoutName = "Layout1",
                IdField = "Id1",
                NameField = "Name1",
                StartDateField = "StartDate1",
                EndDateField = "EndDate1",
                ProgressField = "Progress1",
                ProcessingCounterField = "ProcessingCounter1",
                DependencySourceIdField = "Source1",
                DependencyDestinationIdField = "Dest1",
                OnDataChanged = "Func1",
                SearchCondition = Utilities.CreateSearchCondition("ref1"),
                DependenciesModule = Utilities.CreateSearchCondition("ref2"),
            };
            module.Fields.Add(field);
            var ref1 = Utilities.CreateModule("ref1");
            ref1.DetailLayouts["Layout1"] = new();
            designData.Modules.Add(ref1);
            ref1.Fields.Add(new IdFieldDesign { Name = "Id1" });
            ref1.Fields.Add(new TextFieldDesign { Name = "Name1" });
            ref1.Fields.Add(new DateTimeFieldDesign { Name = "StartDate1" });
            ref1.Fields.Add(new DateTimeFieldDesign { Name = "EndDate1" });
            ref1.Fields.Add(new NumberFieldDesign { Name = "Progress1" });
            ref1.Fields.Add(new NumberFieldDesign { Name = "ProcessingCounter1" });
            var ref2 = Utilities.CreateModule("ref2");
            designData.Modules.Add(ref2);
            ref2.Fields.Add(new IdFieldDesign { Name = "Source1" });
            ref2.Fields.Add(new IdFieldDesign { Name = "Dest1" });
            var ret = field.CheckDesign(new DesignCheckContext("mod", designData, Utilities.CreateDataSource()));
            Assert.That(ret.Count, Is.EqualTo(0));
        }

        [Test]
        public void NoMatchModules()
        {
            var (designData, module) = Utilities.CreateDesignData();
            var field = new FrappeGanttFieldDesign
            {
                Name = "FrappeGantt1",
                DetailLayoutName = "Layout1",
                IdField = "Id1",
                NameField = "Name1",
                StartDateField = "StartDate1",
                EndDateField = "EndDate1",
                ProgressField = "Progress1",
                ProcessingCounterField = "ProcessingCounter1",
                DependencySourceIdField = "Source1",
                DependencyDestinationIdField = "Dest1",
                OnDataChanged = "Func1",
                SearchCondition = Utilities.CreateSearchCondition("ref1"),
                DependenciesModule = Utilities.CreateSearchCondition("ref2"),
            };
            module.Fields.Add(field);
            var ret = field.CheckDesign(new DesignCheckContext("mod", designData, Utilities.CreateDataSource()));
            Assert.That(ret, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(ret[0].Message, Is.EqualTo("モジュール 'ref1' が存在しません。"));
                Assert.That(ret[1].Message, Is.EqualTo("モジュール 'ref2' が存在しません。"));
            });
            ret[0].AssertFieldLocation("mod", "FrappeGantt1", "SearchCondition.ModuleName");
            ret[1].AssertFieldLocation("mod", "FrappeGantt1", "DependenciesModule.ModuleName");
        }

        [Test]
        public void NoMatchFields()
        {
            var (designData, module) = Utilities.CreateDesignData();
            var field = new FrappeGanttFieldDesign
            {
                Name = "FrappeGantt1",
                DetailLayoutName = "Layout1",
                IdField = "Id1",
                NameField = "Name1",
                StartDateField = "StartDate1",
                EndDateField = "EndDate1",
                ProgressField = "Progress1",
                ProcessingCounterField = "ProcessingCounter1",
                DependencySourceIdField = "Source1",
                DependencyDestinationIdField = "Dest1",
                OnDataChanged = "Func1",
                SearchCondition = Utilities.CreateSearchCondition("ref1"),
                DependenciesModule = Utilities.CreateSearchCondition("ref2"),
            };
            module.Fields.Add(field);
            var ref1 = Utilities.CreateModule("ref1");
            ref1.DetailLayouts["Layout1"] = new();
            designData.Modules.Add(ref1);
            var ref2 = Utilities.CreateModule("ref2");
            designData.Modules.Add(ref2);
            var ret = field.CheckDesign(new DesignCheckContext("mod", designData, Utilities.CreateDataSource()));
            Assert.That(ret, Has.Count.EqualTo(8));
            Assert.Multiple(() =>
            {
                Assert.That(ret[0].Message, Is.EqualTo("フィールド 'Id1' がモジュール 'ref1' に存在しません。"));
                Assert.That(ret[1].Message, Is.EqualTo("フィールド 'Name1' がモジュール 'ref1' に存在しません。"));
                Assert.That(ret[2].Message, Is.EqualTo("フィールド 'StartDate1' がモジュール 'ref1' に存在しません。"));
                Assert.That(ret[3].Message, Is.EqualTo("フィールド 'EndDate1' がモジュール 'ref1' に存在しません。"));
                Assert.That(ret[4].Message, Is.EqualTo("フィールド 'Progress1' がモジュール 'ref1' に存在しません。"));
                Assert.That(ret[5].Message, Is.EqualTo("フィールド 'ProcessingCounter1' がモジュール 'ref1' に存在しません。"));
                Assert.That(ret[6].Message, Is.EqualTo("フィールド 'Source1' がモジュール 'ref2' に存在しません。"));
                Assert.That(ret[7].Message, Is.EqualTo("フィールド 'Dest1' がモジュール 'ref2' に存在しません。"));
            });
            ret[0].AssertFieldLocation("mod", "FrappeGantt1", "IdField");
            ret[1].AssertFieldLocation("mod", "FrappeGantt1", "NameField");
            ret[2].AssertFieldLocation("mod", "FrappeGantt1", "StartDateField");
            ret[3].AssertFieldLocation("mod", "FrappeGantt1", "EndDateField");
            ret[4].AssertFieldLocation("mod", "FrappeGantt1", "ProgressField");
            ret[5].AssertFieldLocation("mod", "FrappeGantt1", "ProcessingCounterField");
            ret[6].AssertFieldLocation("mod", "FrappeGantt1", "DependencySourceIdField");
            ret[7].AssertFieldLocation("mod", "FrappeGantt1", "DependencyDestinationIdField");
        }

        [Test]
        public void NoMatchFunctions()
        {
            var (designData, module) = Utilities.CreateDesignData();
            var field = new FrappeGanttFieldDesign
            {
                Name = "FrappeGantt1",
                OnDataChanged = "Func11",
            };
            module.Fields.Add(field);
            var ret = field.CheckDesign(new DesignCheckContext("mod", designData, Utilities.CreateDataSource()));
            Assert.That(ret.Count, Is.EqualTo(1));
            Assert.That(ret[0].Message, Is.EqualTo("関数 'void Func11()' が存在しません。"));
            ret[0].AssertFieldLocation("mod", "FrappeGantt1", "OnDataChanged");
        }

        [Test]
        public void NoMatchLayouts()
        {
            var (designData, module) = Utilities.CreateDesignData();
            var field = new FrappeGanttFieldDesign
            {
                Name = "FrappeGantt1",
                DetailLayoutName = "Layout1",
                SearchCondition = Utilities.CreateSearchCondition("ref1"),
                DependenciesModule = Utilities.CreateSearchCondition("ref2"),
            };
            module.Fields.Add(field);
            var ref1 = Utilities.CreateModule("ref1");
            designData.Modules.Add(ref1);
            var ref2 = Utilities.CreateModule("ref2");
            designData.Modules.Add(ref2);
            var ret = field.CheckDesign(new DesignCheckContext("mod", designData, Utilities.CreateDataSource()));
            Assert.That(ret.Count, Is.EqualTo(1));
            Assert.That(ret[0].Message, Is.EqualTo("レイアウト 'Layout1' がモジュール 'ref1' に存在しません。"));
            ret[0].AssertFieldLocation("mod", "FrappeGantt1", "DetailLayoutName");
        }
    }
}
