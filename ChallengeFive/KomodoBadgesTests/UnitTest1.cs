using KomodoBadgesRepository;

namespace KomodoBadgesTests;

[TestClass]
public class BadgeTests
{
    [TestMethod]
    public void FindCorrectBadge()
    {
        // Arrange
        BadgeList badge = new BadgeList();
        badge.BadgeID = 1;

        // Act
        int expected = 1;
        int actual = badge.BadgeID;

        // Assert
        Assert.AreEqual(expected, actual);
    }
}