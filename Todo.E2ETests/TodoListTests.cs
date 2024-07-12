namespace Todo.E2ETests;

public sealed class TodoListTests : UITestFixture
{
    [Test]
    public void HideDoneItems() =>
        RegisterAsNewUser()
            .AddNewListAndGoToItemCreatePage()
                .Title.SetRandom()
                .Save.ClickAndGo()
            .AddNewItem.ClickAndGo()
                .Title.SetRandom(out var item2Title)
                .Save.ClickAndGo()
            .AddNewItem.ClickAndGo()
                .Title.SetRandom()
                .Save.ClickAndGo()
            .Items[x => x.Title == item2Title].Edit()
                .Done.Check()
                .Save.ClickAndGo()
            .HideDoneItems.Check()
            .Items.Should.HaveCount(2)
            .Items.Should.Not.Contain(x => x.Title == item2Title)
            .HideDoneItems.Uncheck()
            .Items.Should.HaveCount(3)
            .Items.Should.Contain(x => x.Title == item2Title);
}
