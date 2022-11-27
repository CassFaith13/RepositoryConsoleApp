using KomodoCafe_Repo;

namespace KomodoCafeTests;

[TestClass]
public class Tests
{
    [TestMethod]
    public void SetCorrectItem()
    {
        MenuItem item = new MenuItem();
        item.MealName = "Avocado Toast";

        // Act
        string expected = "Avocado Toast";
        string actual = item.MealName;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod] //When you have arguments/parameters you have to use a DataTestMethod and test for every case.
    [DataRow(GlutenStatus.Yes, true)]
    [DataRow(GlutenStatus.No, false)]

    public void GetGlutenFreeStatus(GlutenStatus glutenStatus, bool expectedGlutenStatus)
    {
        MenuItem item = new MenuItem(5,"Thai Summer Salad", "Thai inspired salad with juice seasoned chicken, mandarins, watercress, and a delicious chili peanut dressing!", "marinated chicken, mandarins, watercress, chili peanut dressing", 9.99, glutenStatus);

        bool expected = expectedGlutenStatus;
        bool actual = item.IsGlutenFree;

        Assert.AreEqual(expected, actual);
    }
}