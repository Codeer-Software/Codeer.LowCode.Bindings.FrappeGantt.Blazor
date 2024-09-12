using Codeer.LowCode.Bindings.FrappeGantt.Blazor.Designs;
using Codeer.LowCode.Blazor.DesignLogic;
using Codeer.LowCode.Blazor.DesignLogic.Refactor;
using Codeer.LowCode.Blazor.Repository.Design;

namespace BindingsTest.Rename
{
    public class FrappeGanttFieldDesignTest
    {
        [Test]
        public void ChangeSearchCondition()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                Source = "ref1",
                Destination = "ref2",
                Type = RenameType.Module,
            };
            var field = new FrappeGanttFieldDesign { SearchCondition = Utilities.CreateSearchCondition("ref1") };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.SearchCondition.ModuleName, Is.EqualTo("ref2"));
        }

        [Test]
        public void ChangeDependenciesModule()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                Source = "ref1",
                Destination = "ref2",
                Type = RenameType.Module,
            };
            var field = new FrappeGanttFieldDesign { DependenciesModule = Utilities.CreateSearchCondition("ref1") };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.DependenciesModule.ModuleName, Is.EqualTo("ref2"));
        }

        [Test]
        public void ChangeDetailLayoutName()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                ModuleName = "ref1",
                Source = "Layout1",
                Destination = "Layout2",
                Type = RenameType.Layout,
                LayoutType = ModuleLayoutType.Detail,
            };
            var field = new FrappeGanttFieldDesign
            {
                DetailLayoutName = "Layout1",
                SearchCondition = Utilities.CreateSearchCondition("ref1")
            };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.DetailLayoutName, Is.EqualTo("Layout2"));
        }

        [Test]
        public void ChangeIdField()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                ModuleName = "ref1",
                Source = "Id1",
                Destination = "Id2",
                Type = RenameType.Field,
            };
            var field = new FrappeGanttFieldDesign
            {
                IdField = "Id1",
                SearchCondition = Utilities.CreateSearchCondition("ref1")
            };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.IdField, Is.EqualTo("Id2"));
        }

        [Test]
        public void ChangeNameField()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                ModuleName = "ref1",
                Source = "Name1",
                Destination = "Name2",
                Type = RenameType.Field,
            };
            var field = new FrappeGanttFieldDesign
            {
                NameField = "Name1",
                SearchCondition = Utilities.CreateSearchCondition("ref1")
            };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.NameField, Is.EqualTo("Name2"));
        }

        [Test]
        public void ChangeStartDateField()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                ModuleName = "ref1",
                Source = "StartDate1",
                Destination = "StartDate2",
                Type = RenameType.Field,
            };
            var field = new FrappeGanttFieldDesign
            {
                StartDateField = "StartDate1",
                SearchCondition = Utilities.CreateSearchCondition("ref1")
            };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.StartDateField, Is.EqualTo("StartDate2"));
        }

        [Test]
        public void ChangeEndDateField()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                ModuleName = "ref1",
                Source = "EndDate1",
                Destination = "EndDate2",
                Type = RenameType.Field,
            };
            var field = new FrappeGanttFieldDesign
            {
                EndDateField = "EndDate1",
                SearchCondition = Utilities.CreateSearchCondition("ref1")
            };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.EndDateField, Is.EqualTo("EndDate2"));
        }

        [Test]
        public void ChangeProgressField()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                ModuleName = "ref1",
                Source = "Progress1",
                Destination = "Progress2",
                Type = RenameType.Field,
            };
            var field = new FrappeGanttFieldDesign
            {
                ProgressField = "Progress1",
                SearchCondition = Utilities.CreateSearchCondition("ref1")
            };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.ProgressField, Is.EqualTo("Progress2"));
        }

        [Test]
        public void ChangeProcessingCounterField()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                ModuleName = "ref1",
                Source = "ProcessingCounter1",
                Destination = "ProcessingCounter2",
                Type = RenameType.Field,
            };
            var field = new FrappeGanttFieldDesign
            {
                ProcessingCounterField = "ProcessingCounter1",
                SearchCondition = Utilities.CreateSearchCondition("ref1")
            };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.ProcessingCounterField, Is.EqualTo("ProcessingCounter2"));
        }

        [Test]
        public void ChangeDependencySourceIdField()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                ModuleName = "ref1",
                Source = "Source1",
                Destination = "Source2",
                Type = RenameType.Field,
            };
            var field = new FrappeGanttFieldDesign
            {
                DependencySourceIdField = "Source1",
                DependenciesModule = Utilities.CreateSearchCondition("ref1")
            };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.DependencySourceIdField, Is.EqualTo("Source2"));
        }

        [Test]
        public void ChangeDependencyDestinationIdField()
        {
            var designData = new DesignData();
            var context = new RenameContext(designData)
            {
                ModuleName = "ref1",
                Source = "Dest1",
                Destination = "Dest2",
                Type = RenameType.Field,
            };
            var field = new FrappeGanttFieldDesign
            {
                DependencyDestinationIdField = "Dest1",
                DependenciesModule = Utilities.CreateSearchCondition("ref1")
            };
            var result = field.ChangeName(context);
            Assert.That(result.RenameNeeded);
            result.RenameAction();
            Assert.That(field.DependencyDestinationIdField, Is.EqualTo("Dest2"));
        }
    }
}
